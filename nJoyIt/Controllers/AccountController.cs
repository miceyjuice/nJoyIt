using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using nJoyIt.Models;

namespace nJoyIt.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
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
        public async Task<IActionResult> Login(Login loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginModel.Name);

                if (user != null)
                {
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
            return View(new Register
            {
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(Register registerModel)
        {
            if (!ModelState.IsValid) return View("Register", registerModel);
            var user = new ApplicationUser
            {
                UserName = registerModel.Name,
                Email = "",
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, registerModel.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Book");
                }
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LogOut(string redirectUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(redirectUrl);
        }
    }
}
