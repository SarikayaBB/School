using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace School.Web.Controllers
{
    [Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }

        public IActionResult Teacher()
        {
            return View();
        } public IActionResult Classroom()
        {
            return View();
        }

    }
}