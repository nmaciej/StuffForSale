using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffForSale.Infrastructure;
using StuffForSale.Models;
using StuffForSale.ViewModels;

namespace StuffForSale.Controllers
{
  [Authorize]
  public class UserProfileController : Controller
  {
    public Database.EfcContext DbContext { get; }
    protected UserManager<User> UserManager { get; }
    public UserProfileController(UserManager<User> userManager, Database.EfcContext dbContext)
    {
      UserManager = userManager;
      DbContext = dbContext;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
      var user = await UserManager.GetUserAsync(User);

      var userView = new UserProfile(user, GetMyItems());

      return View(userView);
    }

    [AllowAnonymous]
    public IActionResult GetUserName()
    {
      if (User.Identity.IsAuthenticated)
      {
        return Content(User.Identity.Name);
      }
      return Content("none");
    }

    private IEnumerable<Product> GetMyItems()
    {
      var list = DbContext.Products.Where(x => x.UserId == UserManager.GetUserId(HttpContext.User))
        .Include(x => x.Tag)
        .Include(y => y.User)
        .ToList();
      return list;
    }
  }
}
