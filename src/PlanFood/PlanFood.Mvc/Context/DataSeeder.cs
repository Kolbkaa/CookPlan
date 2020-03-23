using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PlanFood.Mvc.Models.Db;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFood.Mvc.Context
{
    public static class DataSeeder
    {
        private const string AdminPassword = "HasloAdmin_2020";
        private const string AdminLogin = "admin";
        private const string AdminName = "SuperAdmin";
        private const string AdminEmail = "admin@admin.pl";

        public static IApplicationBuilder SeedAdminUser(this IApplicationBuilder app)
        {
            using var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var planFoodContext = service.ServiceProvider.GetRequiredService<PlanFoodContext>();
            var userManager = service.ServiceProvider.GetRequiredService<UserManager<User>>();

            if (planFoodContext.Users.Any()) return app;

            var user = new User()
            {
                UserName = AdminLogin,
                Name = AdminName,
                Email = AdminEmail
            };
            var userTask = userManager.CreateAsync(user, AdminPassword);
            Task.WaitAll(userTask);

            var roleTask = userManager.AddToRoleAsync(user, "admin");
            Task.WaitAll(roleTask);

            return app;
        }
    }
}
