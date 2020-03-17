using PlanFood.Mvc.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFood.Mvc.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<bool> Create(Recipe recipe);
        Task<Recipe> Get(int id);
        Task<IList<Recipe>> GetAll();
        Task<bool> Update(Recipe recipe);
        Task<bool> Delete(int id);
    }
}
