using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StuffForSale.Database;
using StuffForSale.Models;

namespace StuffForSale.Controllers
{
  [Authorize(Roles = "Admin")]
  public class AdminController : Controller
  {
    private readonly Database.EfcContext _dbContext;

    public AdminController(EfcContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IActionResult AdminPanel()
    {
      return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult GetTags()
    {
      return Json(_dbContext.Tags.Include(x=>x.Products).OrderBy(x=>x.Name).ToList(), new JsonSerializerSettings()
      {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
      });
    }

    public async Task<IActionResult> AddTag(string newTag)
    {
      _dbContext.Database.ExecuteSqlCommand("SELECT TOP 0 NULL FROM Tags WITH (TABLOCKX)");
      
      var tagList = await _dbContext.Tags.ToListAsync();

      var test = tagList.SingleOrDefault(x => x.Name == newTag);

      if (test == null)
      {
        await _dbContext.Tags.AddAsync(new Tag() {Name = newTag});
        await _dbContext.SaveChangesAsync();

        return Ok();
      }

      return Conflict();
    }

    [HttpPost]
    public async Task<IActionResult> RemoveTag(int id)
    {
      using (var transaction = _dbContext.Database.BeginTransaction())
      {
        try
        {
          _dbContext.Database.ExecuteSqlCommand("SELECT TOP 0 NULL FROM Products WITH (TABLOCKX)");
          _dbContext.Database.ExecuteSqlCommand("SELECT TOP 0 NULL FROM Tags WITH (TABLOCKX)");

          var tag = await _dbContext.Tags.Include(x => x.Products).SingleOrDefaultAsync(x => x.TagId == id);
          if (tag != null & tag.Products.Count == 0)
          {
            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();
          }
          transaction.Commit();
        }
        catch (Exception e)
        {
          transaction.Rollback();
          return RedirectToAction("AdminPanel", "Admin");
        }
      }
      return RedirectToAction("AdminPanel", "Admin");
    }
  }
}