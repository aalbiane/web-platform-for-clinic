using Microsoft.AspNetCore.Mvc;

namespace Klinika.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
