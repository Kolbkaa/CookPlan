using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanFood.Mvc.Models.Db;

namespace PlanFood.Mvc.Context
{
	public class PlanFoodContext : IdentityDbContext<User,IdentityRole<int>,int>
	{
		public PlanFoodContext(DbContextOptions<PlanFoodContext> options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<RecipePlans> RecipePlans { get; set; }
	}
}
