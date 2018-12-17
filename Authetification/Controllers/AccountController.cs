using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Authetification.ViewModels;
using Authetification.Services;
using Authetification.Models;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace Authetification.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        [Authorize] // этот метод будет доступен только авторизированным
        public IActionResult Index()
        {
            string userName = HttpContext.User.Identity.Name;
            ViewBag.UserName = userName;
            return View();
        }

        //[AllowAnonymous] // этот метод будет доступен всем
        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            accountService.SignUp(model.Email, model.Pswd);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignInViewModel model, string returnUrl = "/Account/Index")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            accountService.SignIn(model.Email, model.Pswd);

            return Redirect(returnUrl);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            accountService.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}