using Microsoft.AspNetCore.Mvc;

namespace School.Web.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
