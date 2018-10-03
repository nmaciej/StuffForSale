using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StuffForSale.Controllers
{
  public class HomeController : Controller
  {
    public Contexts.ProgramDbContext DbContext { get; }
    protected UserManager<IdentityUser> UserManager { get; }

    public HomeController(Contexts.ProgramDbContext context, UserManager<IdentityUser> userManager)
    {
      DbContext = context;
      UserManager = userManager;
    }

    public IActionResult Index()
    {

      var productList = DbContext.Products.Include(x => x.Tag).ToList();
      if (productList.Any())
      {
        return View(productList);
      }

      return View(null);
    }

    public IActionResult LogIn()
    {
      return View();
    }
  }
}
