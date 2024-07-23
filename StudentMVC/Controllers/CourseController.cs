using Microsoft.AspNetCore.Mvc;
using StudentMVC.Interface;
using StudentMVC.Models;
using StudentMVC.Models.ViewModels;

namespace StudentMVC.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseRepository _repo;

        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> List()
        {
            var courses = await _repo.GetCoursesAsync();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCourse course)
        {
            await _repo.AddCourseAsync(course);
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _repo.GetCourseByIdAsync(id);

            if (course == null)
            {
                return View("List");
            }

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            await _repo.EditCourseAsync(course);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repo.DeleteCourseAsync(id)) return RedirectToAction("List");
            return NotFound();
        }
    }
}
