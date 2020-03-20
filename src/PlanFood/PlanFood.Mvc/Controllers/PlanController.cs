using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Models.Db;
using PlanFood.Mvc.Models.ViewModels;
using PlanFood.Mvc.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PlanFood.Mvc.Controllers
{
    [Authorize]
    public class PlanController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPlanService _planService;
        private readonly IDayNameService _dayNameService;

        public PlanController(UserManager<User> userManager, IPlanService planService, IDayNameService dayNameService)
        {
            _userManager = userManager;
            _planService = planService;
            _dayNameService = dayNameService;
        }
        public async Task<IActionResult> List()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var planList = await _planService.GetUserPlanAsync(user);
            return View(planList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPlanViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                ModelState.AddModelError("", "Błąd dodawania planu");
                return View(model);
            }

            var plan = new Plan()
            {
                Name = model.Name,
                Description = model.Description,
                Created = DateTime.Now,
                User = user
            };

            var result = await _planService.CreateAsync(plan);

            if (result == false)
            {
                ModelState.AddModelError("", "Błąd dodawania planu");
                return View(model);
            }

            return RedirectToAction("List", "Plan");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var viewModel = new PlanDetailsViewModel()
            {
                Plan = await _planService.GetWithDetailsAsync(id),
                DayNames = await _dayNameService.GetAllAsync()
            };
            return View(viewModel);
        }
    }
}