using Microsoft.AspNetCore.Mvc;
using School.Repository.Shared.Abstract;

namespace School.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Students.GetAll() });
        }


    }
}
