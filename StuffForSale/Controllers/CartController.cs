using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffForSale.Infrastructure;
using StuffForSale.Models;

namespace StuffForSale.Controllers
{
  [Authorize]
  public class CartController : Controller
  {
    private readonly Database.EfcContext _dbContext;
    private readonly UserManager<User> _userManager;

    public CartController(Database.EfcContext context, UserManager<User> UserManager)
    {
      _dbContext = context;
      _userManager = UserManager;
    }

    public IActionResult Index()
    {
      Cart cart = GetCart();

      return View(cart);
    }

    public IActionResult IndexPartial()
    {
      Cart cart = GetCart();

      return PartialView(cart);
    }

    public async Task<IActionResult> AddToCart(int id)
    {
      Product product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);

      if (product != null)
      {
        Cart cart = GetCart();
        cart.AddItem(product,1);
        SaveCart(cart);
      }
      return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveFromCart(int id)
    {
      Product product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);

      if (product != null)
      {
        Cart cart = GetCart();
        cart.RemoveItem(product,1);
        SaveCart(cart);
      }
      return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveLine(int id)
    {
      Product product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);

      if (product != null)
      {
        Cart cart = GetCart();
        cart.RemoveLine(product);
        SaveCart(cart);
      }
      return RedirectToAction("Index");
    }

    public IActionResult ClearCart()
    {
      Cart cart = GetCart();
      cart.Clear();
      SaveCart(cart);

      return RedirectToAction("Index");
    }

    private Cart GetCart()
    {
      Cart cart = HttpContext.Session.GetJson<Cart>(_userManager.GetUserId(HttpContext.User)) ?? new Cart();
      return cart;
    }

    private void SaveCart(Cart cart)
    {
      HttpContext.Session.SetJson(_userManager.GetUserId(HttpContext.User),cart);
    }

  }
}