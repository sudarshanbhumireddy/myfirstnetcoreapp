using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myfirstnetcoreapp.Models;
using myfirstnetcoreapp.Views.Home.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; }
        private SignInManager<ApplicationUser> _singinManager { get; }
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _singinManager = signInManager;
            
        }
        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"{email} already in use");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _singinManager.SignOutAsync();
            return RedirectToAction("List", "Home");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newuser = new ApplicationUser { UserName = model.Email, Email = model.Email,city=model.city };
                var result = await _userManager.CreateAsync(newuser, model.Password);
                if (result.Succeeded)
                {
                    await _singinManager.SignInAsync(newuser, isPersistent: false);
                    return RedirectToAction("List", "Home");
                }
                foreach (var Error in result.Errors)
                {
                    ModelState.AddModelError("", Error.Description);
                }
            }
            return View();
        }
        [HttpGet]
       [AllowAnonymous]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {

                var result = await _singinManager.PasswordSignInAsync(model.Email, model.Password, model.Rememberme, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                      return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("List", "Home");
                    }
                }
                ModelState.AddModelError("", "Username or password is incorrect");
             }
            return View(model);
           
        }

    }
}

