using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult()
            {
                Content = "<p>Hello from INDEX</p>",
                ContentType = "text/html", // default text/plain
                StatusCode = 200
            };
        }

        public JsonResult GetJson()
        {
            return new JsonResult(new { Id = 3, Name = "Ahmed" });
        }

        public FileStreamResult GetFile()
        {
            return new FileStreamResult(
                new FileStream(
                    @"\\ITSTEP\students redirection$\Ivanchenko\Pictures\progressbar.PNG",
                    FileMode.Open
                    ),
                "image/png"
                )
            { FileDownloadName = "pb.png" };
        }

        public RedirectToActionResult Redirect()
        {
            return new RedirectToActionResult("Index", "Home", null);
        }

        public StatusCodeResult Status()
        {
            return new StatusCodeResult(201);
        }
    }
}