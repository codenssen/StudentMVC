using Microsoft.AspNetCore.Mvc;
using StudentMVC.Interface;
using StudentMVC.Models;
using StudentMVC.Models.ViewModels;
using System.Threading.Tasks;

namespace COREVide.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> List()
        {
            var students = await _repo.GetStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _repo.GetStudentByIdAsync(id);

            if (student == null)
            {
                return View("List");
            }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            await _repo.EditStudentAsync(student);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _repo.DeleteStudentAsync(id)) return RedirectToAction("List");
            return NotFound();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudent student )
        {
            await _repo.AddStudentAsync(student);
            return RedirectToAction("List");
        }
    }
}
