using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Localization.Models;
using System.Globalization;
using Microsoft.Extensions.Localization;

namespace Localization.Controllers
{
    public class HomeController : Controller
    {
        private IStringLocalizer<HomeController> homeLocalizer;
        private IStringLocalizer<SharedResource> sharedResource;

        public HomeController(IStringLocalizer<HomeController> homeLocalizer, IStringLocalizer<SharedResource> sharedResource)
        {
            this.homeLocalizer = homeLocalizer;
            this.sharedResource = sharedResource;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(string lang = "")
        {
            ViewData["Message"] = homeLocalizer["AboutText"];

            //if (!String.IsNullOrEmpty(lang))
            //{
            //    CultureInfo.CurrentCulture = new CultureInfo(lang);
            //    CultureInfo.CurrentUICulture = new CultureInfo(lang);
            //}

            CultureViewModel model = new CultureViewModel()
            {
                Culture = CultureInfo.CurrentCulture.DisplayName,
                UICulture = CultureInfo.CurrentCulture.DisplayName
            };

            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = homeLocalizer["ContactText"];

            ViewData["Hello"] = sharedResource["Hello"];

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
