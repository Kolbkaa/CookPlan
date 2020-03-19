using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanFood.Mvc.Models.Db;

namespace PlanFood.Mvc.Services.Interfaces
{
    public interface IPlanService
    {
        Task<bool> CreateAsync(Plan plan);
        Task<Plan> GetAsync(int id);
        Task<IList<Plan>> GetAllAsync();
        Task<IList<Plan>> GetUserPlanAsync(User user);
        Task<bool> UpdateAsync(Plan plan);
        Task<bool> DeleteAsync(int id);
        Task<int> CountUserPlan(User user);
        Task<Plan> GetLastAddPlan(User user);
    }
}
