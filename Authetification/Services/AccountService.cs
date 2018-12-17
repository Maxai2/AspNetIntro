using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Authetification.EF;
using Authetification.Extensions;
using Authetification.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace Authetification.Services
{
    public class AccountService : IAccountService
    {
        private readonly AuthContext context;
        private readonly HttpContext httpContext;

        public AccountService(AuthContext context, IHttpContextAccessor accessor)
        {
            this.context = context;
            this.httpContext = accessor.HttpContext;
        }

        public User SignUp(string email, string pswd)
        {
            var data = pswd.Encrypt();

            User user = new User()
            {
                Email = email,
                PswdHash = data.pswdhash,
                Salt = data.salt
            };

            context.Users.Add(user);
            context.SaveChanges();

            Authorize(user);

            return user;
        }

        public User SignIn(string email, string pswd)
        {
            User user = context.Users.Where(u => u.Email == email).FirstOrDefault();

            if (user != null && pswd.Sha256(user.Salt) == user.PswdHash)
            {
                Authorize(user);
            }

            return user;
        }

        public void SignOut()
        {
            httpContext.SignOutAsync();
        }

        private void Authorize(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            httpContext.SignInAsync(principal);
        }
    }
}
