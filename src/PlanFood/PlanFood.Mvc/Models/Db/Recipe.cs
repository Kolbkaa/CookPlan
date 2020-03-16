using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFood.Mvc.Models.Db
{
    public class Recipe
    {
		public int Id { get; set; }

		[Required, StringLength(255)]
		public string Name { get; set; }

		[Required, MaxLength]
		public string Ingredients { get; set; }

		[MaxLength]
		public string Description { get; set; }

		[Required]
		public DateTime Created { get; set; }
		
		public DateTime Updated { get; set; }

		[Required]
		public int PreparationTime { get; set; }

		[Required, MaxLength]
		public string Preparation { get; set; }

		//public User User { get; set; }

	}
}
