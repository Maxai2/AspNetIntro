using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Net.Http.Headers;

namespace AspNetIntro.Controllers
{
    public class HomeController : Controller
    {
        // default [HttpGet]
        [HttpGet]
        public IActionResult Index([FromForm] int a)
        {
            return new ContentResult
            {
                Content = "<h1>Hello</h1>",
                StatusCode = 200,
                ContentType = "text/html"
            };
        }

        //[HttpGet]
        public IActionResult Redirect()
        {
            //return Redirect("http://google.com");
            return new RedirectResult("http://google.com");
        }

        public IActionResult Json()
        {
            var obj = new
            {
                Name = "Ali",
                Surname = "Express"
            };

            return new JsonResult(obj);
            //return new StatusCodeResult(404);
        }

        public IActionResult FileRet()
        {
            var text = "hello, asp net core";
            var data = Encoding.Default.GetBytes(text);
            return new FileContentResult(data, "text/plain");
        }

        public IActionResult FileRetStream()
        {
            return new FileStreamResult(
                new FileStream("image.jpg", FileMode.Open), 
                "image/jpg"
                );
        }
    }

}
