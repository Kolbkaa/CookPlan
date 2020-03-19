using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanFood.Mvc.Context;
using PlanFood.Mvc.Models.Db;
using PlanFood.Mvc.Services;
using PlanFood.Mvc.Services.Interfaces;

namespace PlanFood.Mvc
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json").AddEnvironmentVariables("FOODAPP_");
            Configuration = configurationBuilder.Build();
        }
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<PlanFoodContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("SQL")));
            services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<PlanFoodContext>();
			services.Configure<IdentityOptions>(options =>
			{
				options.User.RequireUniqueEmail = true;
			});

			services.AddScoped<IBookService, BookService>();
			services.AddScoped<IRecipeService, RecipeService>();
			services.AddScoped<IDayNameService,DayNameService>();

            services.AddControllersWithViews();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
