using Microsoft.AspNetCore.Mvc;
using School.Repository.Shared.Abstract;

namespace School.Web.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassroomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Classrooms.GetAll().ToList());
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
