using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Models.ViewModels;
using PlanFood.Mvc.Services.Interfaces;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Recipe([FromServices] IRecipeService recipeService,[FromQuery] string search)
        {
            var viewModel = new ListRecipeViewModel();

            if (string.IsNullOrWhiteSpace(search))
            {
                viewModel.RecipeList = await recipeService.GetAllAsync();

            }
            else
            {
                viewModel.RecipeList = await recipeService.GetAllContainsNameAsync(search);
                viewModel.Search = search;
            }

            return View(viewModel);
        }
    }
}