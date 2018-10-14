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
      return View();
    }

    public IActionResult LogIn()
    {
      return View();
    }
  }
}
