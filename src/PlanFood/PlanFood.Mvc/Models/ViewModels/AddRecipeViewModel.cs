using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFood.Mvc.Models.ViewModels
{
    public class AddRecipeViewModel
    {
        [Required(ErrorMessage = "Pole wymagane")]
        public string Name { get; set; }
        [MaxLength(ErrorMessage = "Za dużo znaków")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public int PreparationTime { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        
        public string Preparation { get; set; }
	}
}
