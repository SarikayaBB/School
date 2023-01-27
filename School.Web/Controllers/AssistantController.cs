using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.Models;
using School.Repository.Shared.Abstract;

namespace School.Web.Controllers
{
    public class AssistantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssistantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Assistants.GetAll().ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            AssistantViewModel vm = new AssistantViewModel();
            vm.Teachers = _unitOfWork.Teachers.GetAll().ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Add(Assistant assistant)
        {

            assistant.Teacher = _unitOfWork.Teachers.GetFirstOrDefault(t => t.Id == assistant.TeacherId);
            _unitOfWork.Assistants.Add(assistant);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Assistants.GetAll().ToList());
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            AssistantViewModel vm = new AssistantViewModel();
            Assistant foundAssistant = _unitOfWork.Assistants.GetFirstOrDefault(a => a.Id == id);
            vm.Assistant = foundAssistant;
            List<Teacher> list = new List<Teacher>();
            list.Add(_unitOfWork.Teachers.GetFirstOrDefault(t => t.Id == vm.Assistant.TeacherId));
            list.AddRange(_unitOfWork.Teachers.GetAll().Except(list));
            vm.Teachers = list;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(Assistant assistant)
        {
            Assistant foundAssistant = _unitOfWork.Assistants.GetFirstOrDefault(a=>a.Id == assistant.Id);
            foundAssistant.FullName = assistant.FullName;
            foundAssistant.TeacherId = assistant.TeacherId;
            foundAssistant.DateModified = DateTime.Now;
            foundAssistant.Email = assistant.Email;
            foundAssistant.Sex= assistant.Sex;
            foundAssistant.Phone=assistant.Phone;
            _unitOfWork.Assistants.Update(foundAssistant);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
