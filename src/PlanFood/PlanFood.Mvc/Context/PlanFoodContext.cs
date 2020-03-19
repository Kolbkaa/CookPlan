using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanFood.Mvc.Models.Db;


namespace PlanFood.Mvc.Context
{
	public class PlanFoodContext : IdentityDbContext<User, IdentityRole<int>, int>
	{
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<IdentityRole<int>>().HasData(
				new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "Admin" },
				new IdentityRole<int> { Id = 2, Name = "User", NormalizedName = "USER" });
		}
		public PlanFoodContext(DbContextOptions<PlanFoodContext> options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<RecipePlans> RecipePlans { get; set; }
		public DbSet<DayName> DayNames { get; set; }
		public DbSet<Plan> Plans { get; set; }
	}
}
