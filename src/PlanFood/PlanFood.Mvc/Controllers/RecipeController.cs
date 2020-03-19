using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Models.Db;
using PlanFood.Mvc.Models.ViewModels;
using PlanFood.Mvc.Services.Interfaces;
using System.Threading.Tasks;

namespace PlanFood.Mvc.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IRecipeService _recipeService;

        public RecipeController(UserManager<User> userManager, IRecipeService recipeService)
        {
            _userManager = userManager;
            _recipeService = recipeService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                ModelState.AddModelError("", "Błąd dodawania przepisu.");
                return View(model);
            }

            var recipe = new Recipe()
            {
                Preparation = model.Preparation,
                Name = model.Name,
                PreparationTime = model.PreparationTime,
                Ingredients = model.Ingredients,
                Description = model.Description,
                User = user
                
            };

            var result = await _recipeService.CreateAsync(recipe);

            if (result == false)
            {
                ModelState.AddModelError("", "Błąd dodawania przepisu.");
                return View(model);
            }

            return RedirectToAction("List", "Recipe");
        }
    }
}