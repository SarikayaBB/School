﻿using Microsoft.AspNetCore.Mvc;

namespace School.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
