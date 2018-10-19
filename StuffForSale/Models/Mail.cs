using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using StuffForSale.ViewModels;

namespace StuffForSale.Models
{
  public class Mail
  {
    static int portNumber = 587;
    static bool enableSSL = true;
    static string smtpAddress = "smtp.gmail.com";
    static IConfiguration Configuration { get; set; }

    public Mail(User buyer, User seller, Order order, OrderStateEnum state, IConfiguration config, IEnumerable<OrderDetailSummary> cart = null, List<OrderDetail> orderDetails = null)
    {
      Buyer = buyer;
      Seller = seller;
      Order = order;
      State = state;
      Cart = cart;
      OrderDetailsList = orderDetails;
      Configuration = config;
    }

    public User Buyer;
    public User Seller;
    public Order Order;
    public OrderStateEnum State;
    public IEnumerable<OrderDetailSummary> Cart;
    public List<OrderDetail> OrderDetailsList;

    public bool SendEmail()
    {
      try
      {

        MailAddress to = new MailAddress(Configuration["AdminEmail"]);
        MailAddress from = new MailAddress(Configuration["AdminEmail"]);
        MailMessage mail = new MailMessage(from, to);

        switch (State)
        {
          case OrderStateEnum.Active:
            mail.Subject = $"Flea Market - New Order - {Order.Date} - Buyer: {Buyer.UserName} - Seller: {Seller.UserName}";
            break;
          case OrderStateEnum.Canceled:
            mail.Subject = $"Flea Market - Order Cancel - {Order.Date} - Buyer: {Buyer.UserName} - Seller: {Seller.UserName}";
            break;
          case OrderStateEnum.Completed:
            mail.Subject = $"Flea Market - Order Completed - {Order.Date} - Buyer: {Buyer.UserName} - Seller: {Seller.UserName}";
            break;
        }

        mail.Body = BuildMessage(State);
        mail.To.Add(Configuration["AdminEmail"]);

        SmtpClient smtp = new SmtpClient();
        smtp.Host = smtpAddress;
        smtp.Port = portNumber;
        smtp.Credentials = new System.Net.NetworkCredential(Configuration["AdminEmail"], Configuration["AdminPassword"]);
        smtp.EnableSsl = enableSSL;
        smtp.Send(mail);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public string BuildMessage(OrderStateEnum state)
    {
      switch (state)
      {
        case OrderStateEnum.Active:
          var bodyActive = new StringBuilder();
          bodyActive.Append("\n");
          bodyActive.Append("New order is registered!\n");
          bodyActive.Append("\n");
          bodyActive.Append($"Buyer: {Buyer.UserName}\n");
          bodyActive.Append("\n");
          bodyActive.Append($"Seller: {Seller.UserName}\n");
          bodyActive.Append("\n");
          bodyActive.Append("Order details:\n");
          foreach (var item in Cart)
          {
            bodyActive.Append($"Name: {item.ProductName}, Quantity: {item.Quantity}, Price: {item.Price}\n");
          }
          bodyActive.Append($"Total price: {Cart.Sum(i => i.Quantity * i.Price)}\n");
          bodyActive.Append("\n");
          bodyActive.Append("Delivery to:\n");
          bodyActive.Append($"{Order.Name} {Order.Surname}, {Order.Address}, {Order.City}, {Order.PostCode}\n");
          bodyActive.Append("\n");
          bodyActive.Append("After succesfull transaction pelase confrm it in the user profile panel.\n");
          bodyActive.Append("In other case please cancel the order.\n");
          bodyActive.Append("\n");
          bodyActive.Append("Thank you for using flea market!\n");
          bodyActive.Append("\n");
          return bodyActive.ToString();

        case OrderStateEnum.Canceled:
          var bodyCancel = new StringBuilder();
          bodyCancel.Append($"\n");
          bodyCancel.Append($"Order No. {Order.OrderId} placed by {Order.Name} {Order.Surname} just got canceled.\n");
          bodyCancel.Append($"Please check your user panel if everything is ok.\n");
          bodyCancel.Append($"\n");
          return bodyCancel.ToString();

        case OrderStateEnum.Completed:
          var bodyCompleted = new StringBuilder();
          bodyCompleted.Append($"\n");
          bodyCompleted.Append($"Order No. {Order.OrderId} placed by {Order.Name} {Order.Surname} just got marked as copleted!\n");
          bodyCompleted.Append($"\n");
          bodyCompleted.Append($"Thank you for trusting Flea Market!\n");
          bodyCompleted.Append($"\n");
          return bodyCompleted.ToString();

        default:
          return String.Empty;
      }
    }
  }
}
