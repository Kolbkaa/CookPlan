using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Models.ViewModels;

namespace PlanFood.Mvc.Controllers
{
    //[Authorize]
    public class RecipeController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddRecipeViewModel model)
        {
            return RedirectToAction("List", "Recipe");
        }
    }
}