using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PlanFood.Mvc.Models.Db
{
    public class User:IdentityUser<int>
    {
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Plan> Plans { get; set; }

    }
}
