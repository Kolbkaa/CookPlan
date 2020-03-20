using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFood.Mvc.Models.Db;
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
    }
}