using Microsoft.AspNetCore.Mvc;

namespace StudentMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
