using Microsoft.AspNetCore.Mvc;
using Validation.Models;
using Validation.Services;
using Validation.ViewModels;

namespace Validation.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult All()
        {
            return View(userService.GetUsers());
        }

        [HttpPost]
        public IActionResult CheckEmail(string email)
        {
            if (userService.CheckEmail(email))
            {
                return Json(false);
            }
            return Json(true);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            SignUpViewModel model = new SignUpViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid) // Любые ошибки сюда придут
            {
                return View(model);
            }

            //if (userService.CheckEmail(model.Email))
            //{
            //    ModelState.AddModelError("Email", "Email is already exists.");
            //    return View(model);
            //}

            userService.AddUser(new User()
            {
                Email = model.Email,
                Password = model.Password
            });
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            UserInfoViewModel model = new UserInfoViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Avatar = user.Avatar,
                Birthday = user.Birthday,
                Phone = user.Phone
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UserInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = userService.GetUser(model.Id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = model.Name;
            user.Phone = model.Phone;
            user.Avatar = model.Avatar;
            user.Birthday = model.Birthday;
            return RedirectToAction("All");
        }

    }
}