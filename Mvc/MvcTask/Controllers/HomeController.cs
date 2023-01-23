using Microsoft.AspNetCore.Mvc;

namespace MvcTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
