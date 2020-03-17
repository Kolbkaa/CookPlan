
using Microsoft.EntityFrameworkCore;
using PlanFood.Mvc.Context;
using PlanFood.Mvc.Models.Db;
using PlanFood.Mvc.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFood.Mvc.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly PlanFoodContext _context;

        public RecipeService(PlanFoodContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Recipe recipe)
        {
             await _context.Recipes.AddAsync(recipe);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Recipe> Get(int id)
        {
            return await _context.Recipes.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task <IList<Recipe>> GetAll()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<bool> Update(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var recipe = await _context.Recipes.SingleOrDefaultAsync(b => b.Id == id);
            if (recipe == null)
                return false;

            _context.Recipes.Remove(recipe);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
