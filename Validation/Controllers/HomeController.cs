using Microsoft.AspNetCore.Mvc;

namespace Validation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.IsAuth = true;
            ViewData["IsAuth"] = true;
            return View();
        }
    }
}