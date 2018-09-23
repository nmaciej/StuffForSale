using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StuffForSale.Models;

namespace StuffForSale.Controllers
{
  public class ProductController : Controller
  {
    public Context.Context Context { get; }

    public ProductController(Context.Context context)
    {
      Context = context;
    }


    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Product newProduct)
    {
      if (ModelState.IsValid)
      {
        using (Context)
        {
          Context.Products.Add(newProduct);
          Context.SaveChanges();
        }

        return RedirectToAction("Index", "Home");
      }

      return View(newProduct);
    }


    public IActionResult GetAllProducts()
    {
      var list = Context.Products.ToList();

      return Json(list);
    }

  }
}