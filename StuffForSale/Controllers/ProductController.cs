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
    public Contexts.ProgramDbContext _DbContext { get; }

    public ProductController(Contexts.ProgramDbContext _context)
    {
      _DbContext = _context;
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
        _DbContext.Products.Add(newProduct);
        _DbContext.SaveChanges();

        return RedirectToAction("Index", "Home");
      }

      return View(newProduct);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var list = _DbContext.Products.ToList();

      return Json(list);
    }

  }
}