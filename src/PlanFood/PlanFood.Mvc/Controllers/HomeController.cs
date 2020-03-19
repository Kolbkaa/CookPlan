using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Services.Interfaces;

namespace PlanFood.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public async Task<IActionResult> Recipe([FromServices] IRecipeService recipeService)
        {
            var recipeList = await recipeService.GetAllAsync();
            return View(recipeList);
        }
    }
}