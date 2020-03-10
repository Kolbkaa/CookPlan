using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanFood.Mvc.Models;
using PlanFood.Mvc.Models.Db;

namespace PlanFood.Mvc.Context
{
	public class PlanFoodContext : DbContext
	{
		public PlanFoodContext(DbContextOptions<PlanFoodContext> options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
	}
}
