﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarbleAndEarth.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Heres whats to know";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Contact Us.";

			return View();
		}
	}
}