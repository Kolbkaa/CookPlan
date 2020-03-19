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
        Task<bool> UpdateAsync(Plan plan);
        Task<bool> DeleteAsync(int id);
        Task<int> CountUserPlanAsync(User user);
        Task<Plan> GetLastAddPlanAsync(User user);
        Task<int> CountUserRecipeAsync(User user);
    }
}
