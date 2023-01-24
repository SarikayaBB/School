using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository.Abstract;
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
        public IActionResult GetFirstOrDefault(Student student)
        {
            return Json(_unitOfWork.Students.GetFirstOrDefault(s => s.Id == student.Id));
        }

        public IActionResult Update(List<Classroom> classList, Student student)
        {
            Student foundStudent = _unitOfWork.Students.GetFirstOrDefault(s => s.Id == student.Id);
            foundStudent.Sex = student.Sex;
            foundStudent.DateModified = DateTime.Now;
            foundStudent.Email = student.Email;
            foundStudent.FullName = student.FullName;
            student.Phone = student.Phone.Replace("-", String.Empty);
            student.Phone = student.Phone.Replace("(", String.Empty);
            student.Phone = student.Phone.Replace(")", String.Empty);
            foundStudent.Phone = student.Phone;
            try
            {
                foundStudent.Classrooms.Clear();
            }
            catch
            {

            }
            foundStudent.Classrooms = _unitOfWork.Classrooms.FindClasses(classList);
            _unitOfWork.Students.Update(foundStudent);
            _unitOfWork.Save();
            return Json(foundStudent);
        }

    }
}
