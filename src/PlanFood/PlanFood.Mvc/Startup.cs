using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlanFood.Mvc.Context;
using PlanFood.Mvc.Services;
using PlanFood.Mvc.Services.Interfaces;

namespace PlanFood.Mvc
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<PlanFoodContext>(builer => builer.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=PlanFood;Integrated Security=True"));

			services.AddScoped<IBookService, BookService>();
			services.AddScoped<IDayNameService,DayNameService>();

            services.AddControllersWithViews();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseRouting();


			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
