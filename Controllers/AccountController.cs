using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using nJoyIt.Models;

namespace nJoyIt.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (_signInManager.IsSignedIn(User)) return RedirectToAction("Index", "Book");
            return View(new Login
            {
                ReturnUrl = returnUrl
            });
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginModel.Name);

                if (user != null)
                {
                    /*await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        Console.WriteLine("Successfully logged in!");
                        return Redirect(loginModel.ReturnUrl ?? "/Admin/Index");
                    }*/

                    var signInResult = await _signInManager.PasswordSignInAsync(loginModel.Name, loginModel.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        return Redirect(loginModel.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Wrong username or password!");
            return View(loginModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new Login
            {
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Login loginModel)
        {
            var user = new IdentityUser
            {
                UserName = loginModel.Name,
                Email = "",
            };

            var result = await _userManager.CreateAsync(user, loginModel.Password);

            if (result.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Book");
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
