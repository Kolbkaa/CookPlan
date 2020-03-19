using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanFood.Mvc.Context;
using PlanFood.Mvc.Models.Db;
using PlanFood.Mvc.Services.Interfaces;

namespace PlanFood.Mvc.Services
{
    public class PlanService : IPlanService
    {
        private readonly PlanFoodContext _context;
        public PlanService(PlanFoodContext context)
        {
            this._context = context;
        }

        public async Task<bool> CreateAsync(Plan plan)
        {
            _context.Plans.Add(plan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Plan> GetAsync(int id)
        {
            return await _context.Plans.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Plan>> GetAllAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Plan plan)
        {
            _context.Plans.Update(plan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plan = _context.Plans.SingleOrDefault(x => x.Id == id);
            if (plan == null) return false;

            _context.Plans.Remove(plan);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> CountUserPlanAsync(User user)
        {
            return await _context.Plans.Where(plan => plan.User.Equals(user)).CountAsync();
        }

        public async Task<Plan> GetLastAddPlanAsync(User user)
        {
            return await _context.Plans.Include(plan => plan.RecipePlans).ThenInclude(recipePlans => recipePlans.DayName)
                .Where(plan => plan.User.Equals(user)).OrderByDescending(plan => plan.Created).FirstOrDefaultAsync();
        }

    }
}
