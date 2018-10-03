using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StuffForSale.Models;
using StuffForSale.ViewModels;

namespace StuffForSale.Controllers
{

  public class ProductController : Controller
  {
    public Contexts.ProgramDbContext DbContext { get; }
    protected UserManager<IdentityUser> UserManager { get; }

    public ProductController(Contexts.ProgramDbContext context, UserManager<IdentityUser> userManager)
    {
      DbContext = context;
      UserManager = userManager;
    }

    [Authorize]
    [HttpGet]
    public IActionResult Add()
    {
      //Passing logged userId to View
      var userId = UserManager.GetUserId(HttpContext.User);
      var tagDict = DbContext.Tags.ToDictionary(x => (int)x.TagId, x => x.Name.ToString());

      return View(new ProductAdd(new Product(userId),tagDict ));
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(ProductAdd productViewModel)
    {
      if (ModelState.IsValid)
      {
        DbContext.Products.Add(productViewModel.Product);
        DbContext.SaveChanges();

        return RedirectToAction("Index", "Home");
      }

      return View(productViewModel);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      if (DbContext.Products.Any())
      {
        var list = DbContext.Products.ToList();
        return Json(list);
      }
      return Json(null);
    }

  }
}