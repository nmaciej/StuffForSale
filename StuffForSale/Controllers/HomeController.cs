using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffForSale.Models;

namespace StuffForSale.Controllers
{
  public class HomeController : Controller
  {
    public Database.EfcContext DbContext { get; }
    protected UserManager<User> UserManager { get; }

    public HomeController(Database.EfcContext context, UserManager<User> userManager)
    {
      DbContext = context;
      UserManager = userManager;
    }

    public IActionResult Index()
    {

      var productList = DbContext.Products.Where(x=>x.Quantity!=0).Include(x=>x.User).Include(y=>y.Tag).ToList();
      if (productList.Any())
      {
        return View(productList);
      }

      return View(new List<Product>());
    }

    public IActionResult LogIn()
    {
      return View();
    }
  }
}
