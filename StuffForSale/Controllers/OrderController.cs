using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using StuffForSale.Infrastructure;
using StuffForSale.Models;
using StuffForSale.ViewModels;

namespace StuffForSale.Controllers
{
  [Authorize]
  public class OrderController : Controller
  {
    private readonly Database.EfcContext _dbContext;
    private readonly UserManager<User> _userManager;

    private object _lock = new object();

    public OrderController(Database.EfcContext context, UserManager<User> UserManager)
    {
      _dbContext = context;
      _userManager = UserManager;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
      var order = new Order() { BuyerId = _userManager.GetUserId(HttpContext.User) };

      return View(order);
    }

    //Order summary
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult PrivateSummary(Order order)
    {

      if (!CheckCart())
      {
        return RedirectToAction("Index", "Cart");
      }

      var cart = GetCart();
      var orderDetailsList = new List<OrderDetailSummary>();

      if (cart.CartLinesCollection.Count == 0)
      {
        RedirectToAction("Index", "Home");
      }

      foreach (var line in cart.CartLinesCollection)
      {
        var tmp = new OrderDetailSummary()
        {
          Price = line.Product.Price,
          Quantity = line.Quantity,
          ProductId = line.Product.ProductId,
          ProductName = line.Product.Name,
          SellerId = line.Product.UserId,
          SellerName = _dbContext.Users.SingleOrDefault(u => u.Id == line.Product.UserId).UserName
        };

        orderDetailsList.Add(tmp);
      }

      var viewModel = new OrderSummary()
      {
        Order = order,
        OrderDetailsSummaryList = orderDetailsList
      };

      return View(viewModel);
    }

    //Processing order
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult PrivateConfirmed(OrderSummary orderSummary)
    {
      //Transaction - if any DB update will go wrong performs rollback
      using (var transaction = _dbContext.Database.BeginTransaction())
      {
        try
        {
          //Locks Products table - other users need to wait
          _dbContext.Database.ExecuteSqlCommand("SELECT TOP 0 NULL FROM Products WITH (TABLOCKX)");

          if (!CheckCart())
          {
            return RedirectToAction("Index", "Cart");
          }

          var order = orderSummary.Order;
          var myCart = orderSummary.OrderDetailsSummaryList;

          //Create separate order and separate order details for each seller
          var sellers = myCart.GroupBy(x => x.SellerId).Select(y => y.First().SellerName);

          foreach (var seller in sellers)
          {
            //Clone order
            var tmpOrder = new Order()
            {
              OrderId = order.OrderId,
              Date = order.Date,
              State = order.State,
              Name = order.Name,
              Surname = order.Surname,
              Address = order.Address,
              PostCode = order.PostCode,
              City = order.City,
              BuyerId = order.BuyerId,
              SellerId = _dbContext.Users.SingleOrDefault(x => x.UserName == seller).Id
            };

            //Push tmpOrder to database
            _dbContext.Orders.Add(tmpOrder);
            _dbContext.SaveChanges();

            //Get tmpOrder Order table Id
            var newId = tmpOrder.OrderId;

            //Map myCart to OrderDetails list. One per each seller
            var cartBySeller = myCart.Where(x => x.SellerName == seller);
            var tmp = new List<OrderDetail>();
            foreach (var item in cartBySeller)
            {
              var pr = _dbContext.Products.SingleOrDefault(x => x.ProductId == item.ProductId);
              pr.Quantity -= item.Quantity;

              var newLine = new OrderDetail()
              {
                OrderDetailId = 0,
                OrderId = newId,
                Price = item.Price,
                ProductId = item.ProductId,
                Quantity = item.Quantity
              };
              tmp.Add(newLine);
            }

            //Update OrderDetails table
            _dbContext.OrderDetails.AddRange(tmp);
            _dbContext.SaveChanges();

            //Send out emails
            var userSeller = _dbContext.Users.SingleOrDefault(z => z.UserName == seller);
            var userBuyer = _dbContext.Users.SingleOrDefault(x => x.Id == GetUserId());
            var mailing = new Mail(userBuyer, userSeller, tmpOrder, OrderStateEnum.Active, cartBySeller, null);
            mailing.SendEmail();
          }
          //Clear Cart Session
          Cart cart = GetCart();
          cart.Clear();
          SaveCart(cart);

          transaction.Commit();
        }
        catch (Exception e)
        {
          transaction.Rollback();
          return RedirectToAction("Index", "Home");
        }
      }

      return RedirectToAction("Index", "UserProfile");
    }

    [HttpPost]
    public IActionResult GetOrdersForCustomer(bool buyer)
    {
      var orders = buyer
        ? _dbContext.Orders.Where(x => x.BuyerId == GetUserId()).Include(y => y.UserSeller).Include(x => x.UserBuyer)
          .Include(z => z.OrderDetails).ToList()
        : _dbContext.Orders.Where(x => x.SellerId == GetUserId()).Include(y => y.UserSeller).Include(x => x.UserBuyer)
          .Include(z => z.OrderDetails).ToList();

      var viewModel = new List<object>();
      foreach (var item in orders)
      {
        viewModel.Add(new
        {
          OrderId = item.OrderId,
          Seller = item.UserSeller.UserName,
          Buyer = item.UserBuyer.UserName,
          Quantity = item.OrderDetails.Sum(x => x.Quantity),
          Price = item.OrderDetails.Sum(x => x.Price * x.Quantity),
          Date = item.Date,
          InProcess = item.State
        });
      }
      return Json(viewModel);
    }

    [HttpPost]
    public IActionResult OrderConfirm(int orderId)
    {
      var order = _dbContext.Orders.SingleOrDefault(x => x.OrderId == orderId);
      if (order != null)
      {
        order.State = OrderStateEnum.Completed;
        _dbContext.SaveChanges();

        var userSeller = _dbContext.Users.SingleOrDefault(z => z.Id == order.SellerId);
        var userBuyer = _dbContext.Users.SingleOrDefault(z => z.Id == order.BuyerId);

        var mailing = new Mail(userBuyer, userSeller, order, OrderStateEnum.Completed, null, null);
        mailing.SendEmail();

        return Ok();
      }
      return BadRequest();
    }

    [HttpPost]
    public IActionResult OrderCancel(int orderId)
    {
      using (var transaction = _dbContext.Database.BeginTransaction())
      {
        try
        {
          _dbContext.Database.ExecuteSqlCommand("SELECT TOP 0 NULL FROM Products WITH (TABLOCKX)");

          var order = _dbContext.Orders.SingleOrDefault(x => x.OrderId == orderId);
          if (order != null)
          {
            order.State = OrderStateEnum.Canceled;
            var orderDetails = _dbContext.OrderDetails.Where(x => x.OrderId == orderId).ToList();

            var productList = new List<Product>();
            foreach (var item in orderDetails)
            {
              productList.Add(_dbContext.Products.SingleOrDefault(x => x.ProductId == item.ProductId));
              productList.Last().Quantity += item.Quantity;
            }
            _dbContext.SaveChanges();

            var userSeller = _dbContext.Users.SingleOrDefault(z => z.Id == order.SellerId);
            var userBuyer = _dbContext.Users.SingleOrDefault(z => z.Id == order.BuyerId);

            var mailing = new Mail(userBuyer, userSeller, order, OrderStateEnum.Canceled, null, orderDetails);
            mailing.SendEmail();

            return Ok();
          }

          transaction.Commit();
        }
        catch (Exception e)
        {
          transaction.Rollback();
          return RedirectToAction("Index", "UserProfile");
        }
      }
      return RedirectToAction("Index", "UserProfile");
    }

    //Supporting methods

    private string GetUserId()
    {
      return _userManager.GetUserId(HttpContext.User);
    }

    private Cart GetCart()
    {
      Cart cart = HttpContext.Session.GetJson<Cart>(GetUserId()) ?? new Cart();
      return cart;
    }

    private void SaveCart(Cart cart)
    {
      HttpContext.Session.SetJson(GetUserId(), cart);
    }

    private bool CheckCart()
    {
      var userCart = GetCart();
      bool flag = true;

      foreach (var item in userCart.CartLinesCollection)
      {
        var product = _dbContext.Products.SingleOrDefault(x => x.ProductId == item.Product.ProductId);

        if (product.Quantity < item.Quantity)
        {
          item.Quantity = product.Quantity;
          flag = false;
        }
      }
      userCart.CartLinesCollection = userCart.CartLinesCollection.Where(x => x.Quantity != 0).ToList();
      SaveCart(userCart);

      return flag;
    }
  }
}