using Microsoft.AspNetCore.Mvc;

namespace HtmlHelpers.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}