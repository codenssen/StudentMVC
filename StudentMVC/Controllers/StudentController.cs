using Microsoft.AspNetCore.Mvc;
using StudentMVC.Interface;
using StudentMVC.Models;
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
            await _repo.DeleteStudentAsync(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(string name, string lastname)
        {
            await _repo.AddStudentAsync(name, lastname);
            return RedirectToAction("List");
        }
    }
}
