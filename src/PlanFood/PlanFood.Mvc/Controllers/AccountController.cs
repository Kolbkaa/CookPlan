using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Models;
using PlanFood.Mvc.Models.Db;
using PlanFood.Mvc.Models.ViewModels;

namespace PlanFood.Mvc.Controllers
{
    public class AccountController : Controller
    {
        protected UserManager<User> UserManager { get; }
        protected SignInManager<User> SignInManager { get; }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            SignInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Error = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = registerViewModel.Name,
                    UserName = registerViewModel.Email,
                    Surname = registerViewModel.Surname,
                    Email = registerViewModel.Email,
                };
                var result = await UserManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Index", "Home"); //         <-------------zmienic na Login po implementacji akcji Login
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.Error = true;
            return View(registerViewModel);
        }
    }
}