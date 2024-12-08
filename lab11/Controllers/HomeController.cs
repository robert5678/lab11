using Microsoft.AspNetCore.Mvc;

namespace lab11.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return Content("Це сторінка 'Про нас'.");
        }
    }
}
