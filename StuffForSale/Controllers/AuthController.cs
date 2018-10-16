using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffForSale.Models;
using StuffForSale.ViewModels;

namespace StuffForSale.Controllers
{
  public class AuthController : Controller
  {
    protected UserManager<User> UserManager { get; }
    protected SignInManager<User> SignInManager { get; }
    protected RoleManager<User> RoleManager { get; }
    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<User> roleManager)
    {
      UserManager = userManager;
      SignInManager = signInManager;
      RoleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Test()
    {
      return Content("test");
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegister registerViewModel)
    {
      if (ModelState.IsValid)
      {
        var userTaken = await UserManager.Users.AnyAsync(x => x.UserName == registerViewModel.Login);
        var emailTaken = await UserManager.Users.AnyAsync(x => x.Email == registerViewModel.Email);

        if (userTaken || emailTaken)
        {
          if (userTaken) ModelState.AddModelError("", "This login is already in use!");
          if (emailTaken) ModelState.AddModelError("", "This email is already in use!");

          return View(registerViewModel);
        }

        var user = new User() { UserName = registerViewModel.Login, Email = registerViewModel.Email };
        var result = await UserManager.CreateAsync(user, registerViewModel.Password);
        if (result.Succeeded)
        {


          var login = await SignInManager.PasswordSignInAsync(registerViewModel.Login,
            registerViewModel.Password, false, false);

          return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError("", "Could not Log In this user!");
        foreach (var error in result.Errors)
        {
          ModelState.AddModelError("", error.Description);
        }
      }
      return View(registerViewModel);
    }

    [HttpGet]
    public IActionResult LogIn()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(UserLogIn logInViewModel)
    {
      if (ModelState.IsValid)
      {
        //if (await SignInManager.UserManager.Users.AnyAsync(x => x.UserName != logInViewModel.Login))
        //{
        //  ModelState.AddModelError("", "There is no such user!");
        //  return View(logInViewModel);
        //}

        var result = await SignInManager.PasswordSignInAsync(logInViewModel.Login,
          logInViewModel.Password, logInViewModel.RememberMe, false);
        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError("", "Could not Log In this user!");
      }
      return View(logInViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
      await SignInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
  }
}