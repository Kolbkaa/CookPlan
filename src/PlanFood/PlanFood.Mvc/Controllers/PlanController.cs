using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Models.Db;
using PlanFood.Mvc.Models.ViewModels;
using PlanFood.Mvc.Services.Interfaces;

namespace PlanFood.Mvc.Controllers
{
    [Authorize]
    public class PlanController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPlanService _planService;

        public PlanController(UserManager<User> userManager, IPlanService planService)
        {
            _userManager = userManager;
            _planService = planService;
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
    }
}