using PlanFood.Mvc.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFood.Mvc.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<bool> CreateAsync(Recipe recipe);
        Task<Recipe> GetAsync(int id);
        Task<IList<Recipe>> GetAllAsync();
        Task<bool> UpdateAsync(Recipe recipe);
        Task<bool> DeleteAsync(int id);
        Task<int> CountRecipesAsync(User user);
        Task<int> CountUserRecipeAsync(User user);
    }
}
