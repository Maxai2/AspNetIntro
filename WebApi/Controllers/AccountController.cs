using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("Login")] // api/account/login
        public IActionResult Login([FromBody]LoginRequest model)
        {
            LoginResponse resp = accountService.LogIn(model.Login, model.Password);

            if (resp == null)
                return BadRequest();
            else
                return new JsonResult(resp);
        }

        public class TokenRequest
        {
            public string RefreshToken { get; set; }
        }

        [HttpPost("Token")] // api/account/token
        public IActionResult UpdateToken([FromBody]TokenRequest request)
        {
            LoginResponse resp = accountService.UpdateToken(request.RefreshToken);

            if (resp == null)
                return StatusCode(400);
            else
                return new JsonResult(resp);
        }

        [Authorize]
        [HttpGet("")] // api/account
        public IActionResult GetInfo()
        {
            string id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (id == null)
                return NotFound();

            Account acc = accountService.GetInfo(Int32.Parse(id));

            if (acc == null)
                return NotFound();

            return new JsonResult(acc);
        }

        [Authorize]
        [HttpGet("LogOut")] // api/account/logout
        public IActionResult LogOut()
        {
            string id = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

            if (id == null)
                return Ok();

            accountService.LogOut(Int32.Parse(id));
            return Ok();
        }
    }
}
