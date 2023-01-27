using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository.Shared.Abstract;
using School.Repository.Shared.Shared;

namespace School.Web.Controllers
{
    public class TeacherController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unifOfWork)
        {
            _unitOfWork = unifOfWork;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Teachers.GetAll() });
        }
        public IActionResult GetFirstOrDefault(Teacher teacher)
        {
            return Json(_unitOfWork.Teachers.GetFirstOrDefault(s => s.Id == teacher.Id));
        }

        public IActionResult Update(List<Classroom> classes, Teacher teacher)
        {
            Teacher foundTeacher = _unitOfWork.Teachers.GetFirstOrDefault(s => s.Id == teacher.Id);
            foundTeacher.Sex = teacher.Sex;
            foundTeacher.DateModified = DateTime.Now;
            foundTeacher.Email = teacher.Email;
            foundTeacher.FullName = teacher.FullName;
            teacher.Phone = teacher.Phone.Replace("-", String.Empty);
            teacher.Phone = teacher.Phone.Replace("(", String.Empty);
            teacher.Phone = teacher.Phone.Replace(")", String.Empty);
            foundTeacher.Phone = teacher.Phone;
            try
            {
                foundTeacher.Classrooms.Clear();
            }
            catch
            {
            }

            foundTeacher.Classrooms = _unitOfWork.Classrooms.FindClasses(classes);
            _unitOfWork.Teachers.Update(foundTeacher);
            _unitOfWork.Save();
            return Json(foundTeacher);
        }
        public IActionResult DeleteClass(Guid classId, Guid teacherId)
        {
            Teacher teacher = _unitOfWork.Teachers.GetFirstOrDefault(s => s.Id == teacherId);
            Classroom classroom = _unitOfWork.Classrooms.GetFirstOrDefault(c => c.Id == classId);
            teacher.Classrooms.Remove(classroom);
            teacher.DateModified = DateTime.Now;
            _unitOfWork.Teachers.Update(teacher);
            _unitOfWork.Save();
            return Json(new { teacher = teacher, classroom = classroom });
        }
        public IActionResult Delete(Guid teacherId)
        {
            Teacher foundTeacher = _unitOfWork.Teachers.GetFirstOrDefault(s => s.Id == teacherId);
            _unitOfWork.Teachers.Remove(foundTeacher);
            _unitOfWork.Save();
            return Json(foundTeacher);

        }
        public IActionResult Add(List<Classroom> classes, Teacher teacher)
        {
            teacher.Phone = teacher.Phone.Replace("-", String.Empty);
            teacher.Phone = teacher.Phone.Replace("(", String.Empty);
            teacher.Phone = teacher.Phone.Replace(")", String.Empty);
            teacher.Classrooms = _unitOfWork.Classrooms.FindClasses(classes);
            _unitOfWork.Teachers.Add(teacher);
            _unitOfWork.Save();
            return Json(teacher);
        }


    }
}
