﻿using Microsoft.AspNetCore.Mvc;

namespace School.Web.Controllers
{
    public class ClassroomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
