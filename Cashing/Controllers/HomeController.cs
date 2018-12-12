using Microsoft.AspNetCore.Mvc;

namespace Caching.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 85, Location = ResponseCacheLocation.Client)]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}