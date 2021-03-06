﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StuffForSale.Models;
using StuffForSale.ViewModels;
using Microsoft.Extensions.Configuration;

namespace StuffForSale.Controllers
{
  public class AuthController : Controller
  {
    protected UserManager<User> UserManager { get; }
    protected SignInManager<User> SignInManager { get; }
    protected RoleManager<IdentityRole> RoleManager { get; }
    protected IConfiguration Configuration { get; set; }
    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
    {
      UserManager = userManager;
      SignInManager = signInManager;
      RoleManager = roleManager;
      Configuration = config;
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
      if (!UserManager.Users.Any())
      {
        await RoleManager.CreateAsync(new IdentityRole("Admin"));
        await RoleManager.CreateAsync(new IdentityRole("User"));

        var user = new User() { UserName = Configuration["AdminLogin"], Email = Configuration["AdminEmail"] };
        var result = await UserManager.CreateAsync(user, Configuration["AdminPassword"]);

        if (result.Succeeded)
        {
          await UserManager.AddToRolesAsync(user, new List<string> { "Admin" });
        }
      }
      return View();
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
          await UserManager.AddToRolesAsync(user, new List<string> { "User" });

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