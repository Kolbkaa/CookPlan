﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlanFood.Mvc.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
		    return View();
		}

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }
	}
}