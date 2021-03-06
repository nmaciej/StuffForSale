﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using StuffForSale.Models;
using StuffForSale.ViewModels;

namespace StuffForSale.Controllers
{

  public class ProductController : Controller
  {
    private readonly Database.EfcContext _dbContext;
    private readonly UserManager<User> _userManager;

    public int PageSize = 3;

    public ProductController(Database.EfcContext context, UserManager<User> userManager)
    {
      _dbContext = context;
      _userManager = userManager;
    }

    [Authorize]
    [HttpGet]
    public IActionResult Add()
    {
      //Passing logged userId to View
      var userId = GetUserId();
      var tagDict = _dbContext.Tags.ToDictionary(x => (int)x.TagId, x => x.Name.ToString());

      return View(new ProductAdd(new Product(userId), tagDict));
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(ProductAdd productViewModel)
    {
      if (ModelState.IsValid)
      {
        _dbContext.Products.Add(productViewModel.Product);
        _dbContext.SaveChanges();

        return RedirectToAction("Index", "UserProfile");
      }
      return View(productViewModel);
    }

    [Authorize]
    [HttpPost]
    public IActionResult AddItem(int id)
    {
      using (var transaction = _dbContext.Database.BeginTransaction())
      {
        try
        {
          _dbContext.Database.ExecuteSqlCommand("SELECT TOP 0 NULL FROM Products WITH (TABLOCKX)");

          var product = _dbContext.Products.SingleOrDefault(x => x.ProductId == id);
          if (product != null)
          {
            product.Quantity++;
            _dbContext.SaveChanges();
          }
          transaction.Commit();
        }
        catch (Exception)
        {
          transaction.Rollback();
          return RedirectToAction("Index", "UserProfile");
        }
      }
      return RedirectToAction("Index", "UserProfile");
    }

    [Authorize]
    [HttpPost]
    public IActionResult RemoveItem(int id)
    {
      using (var transaction = _dbContext.Database.BeginTransaction())
      {
        try
        {
          _dbContext.Database.ExecuteSqlCommand("SELECT TOP 0 NULL FROM Products WITH (TABLOCKX)");

          var product = _dbContext.Products.SingleOrDefault(x => x.ProductId == id);
          if (product != null & product.Quantity >= 1)
          {
            product.Quantity--;
            _dbContext.SaveChanges();
          }
          transaction.Commit();
        }
        catch (Exception)
        {
          transaction.Rollback();
          return RedirectToAction("Index", "UserProfile");
        }
      }
      return RedirectToAction("Index", "UserProfile");
    }

    [Authorize]
    [HttpPost]
    public IActionResult RemoveLine(int id)
    {
      using (var transaction = _dbContext.Database.BeginTransaction())
      {
        try
        {
          _dbContext.Database.ExecuteSqlCommand("SELECT TOP 0 NULL FROM Products WITH (TABLOCKX)");

          var product = _dbContext.Products.SingleOrDefault(x => x.ProductId == id);
          if (product != null)
          {
            product.Quantity = 0;
            _dbContext.SaveChanges();
          }
          transaction.Commit();
        }
        catch (Exception)
        {
          transaction.Rollback();
          return RedirectToAction("Index", "UserProfile");
        }
      }
      return RedirectToAction("Index", "UserProfile");
    }

    [HttpPost]
    public IActionResult GetAll(string tag = null, int productPage = 1)
    {
      var productList = new List<Product>();
      int ItemsCount;
      if (tag == null)
      {
        var tmp = _dbContext.Products.Where(x => x.Quantity != 0)
          .OrderBy(x => x.Name)
          .Include(x => x.User)
          .Include(y => y.Tag)
          .ToList();

        ItemsCount = tmp.Count;

        productList = tmp.Skip((productPage - 1) * PageSize).Take(PageSize).ToList();

      }
      else
      {
        var tmp = _dbContext.Products.Where(x => x.Quantity != 0).OrderBy(x => x.Name).Include(x => x.User).Include(y => y.Tag).Where(x => x.Tag.Name == tag).ToList();
        
        ItemsCount = tmp.Count;

        productList = tmp.Skip((productPage - 1) * PageSize).Take(PageSize).ToList();
      }

      var pages = 0;
      if (ItemsCount % PageSize == 0)
      {
        pages = (int)ItemsCount / PageSize;
      }
      else
      {
        pages = (int)ItemsCount / PageSize + 1;
      }

      var result = new ProductGetAll()
      {
        ProductList = productList,
        CurrentPage = productPage,
        Items = ItemsCount,
        Pages = pages,
        PerPage = PageSize,
        Tag = tag
      };

      return Json(result, new JsonSerializerSettings()
      {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
      });
    }

    private string GetUserId()
    {
      return _userManager.GetUserId(HttpContext.User);
    }
  }
}