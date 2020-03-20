using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Models.Db;
using PlanFood.Mvc.Models.ViewModels;
using PlanFood.Mvc.Services;
using PlanFood.Mvc.Services.Interfaces;

namespace PlanFood.Mvc.Controllers
{
    //[Authorize]
    public class DashboardController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IPlanService _planService;
        protected UserManager<User> UserManager { get; }

        public DashboardController(IRecipeService recipeService, IPlanService planService, UserManager<User> userManager)
        {
            _recipeService = recipeService;
            _planService = planService;
            UserManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await UserManager.GetUserAsync(User);
            var dasboardViewModel = new DashboardViewModel()
            {
                RecipeNumber = await _recipeService.CountRecipesAsync(user),
                Plan = await _planService.GetLastAddPlanAsync(user),
                PlanNumber = await _planService.CountUserPlanAsync(user)
            };
            return View(dasboardViewModel);
        }
    }
}