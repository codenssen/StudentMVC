using Microsoft.AspNetCore.Mvc;

namespace StudentMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Int32> ids = new List<Int32>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            return View(ids);
        }
    }
}
