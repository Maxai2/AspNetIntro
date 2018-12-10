using Microsoft.AspNetCore.Mvc;

namespace Validation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}