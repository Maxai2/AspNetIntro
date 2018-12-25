using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Services
{
    public class AccountService : IAccountService
    {
        private List<Account> accounts;
        private List<AccountToken> accountTokens;

        public AccountService()
        {
            this.accounts = new List<Account>()
            {
                new Account() { Id = 1, Login = "user1", Role = "user", Password = "1111", About = "About user1"},
                new Account() { Id = 2, Login = "user2", Role = "admin", Password = "1111", About = "About admin1"}
            };

            accountTokens = new List<AccountToken>();
        }

        public LoginResponse UpdateToken(string refreshToken)
        {
            AccountToken accountToken = accountTokens.Find(at => at.RefreshToken == refreshToken);

            if (accountToken == null)
                return null;

            if (accountToken.Expires <= DateTime.Now)
                return null;

            Account account = accounts.Find(a => a.Id == accountToken.AccountId);

            if (account == null)
                return null;

            return Authentication(account);
        }

        public Account GetInfo(int id)
        {
            return accounts.Find(a => a.Id == id);
        }

        public LoginResponse LogIn(string login, string password)
        {
            Account acc = accounts.Find(a => a.Login == login && a.Password == password);

            if (acc == null)
                return null;
            else
                return Authentication(acc);
        }

        private LoginResponse Authentication(Account account)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, account.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, account.Role),
                new Claim("id", account.Id.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            JwtSecurityToken token = new JwtSecurityToken
                (
                    issuer: "WebApiEx",
                    audience: "http://localhost:60252/",
                    claims: claimsIdentity.Claims,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.Default.GetBytes("my_security_key_1234567890")), SecurityAlgorithms.HmacSha256)
                );

            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponse resp = new LoginResponse()
            {
                AccessToken = tokenStr,
                Login = account.Login,
                RefreshToken = Guid.NewGuid().ToString()
            };

            accountTokens.RemoveAll(at => at.AccountId == account.Id);

            accountTokens.Add(new AccountToken()
            {
                AccountId = account.Id,
                Expires = DateTime.Now.AddMinutes(10),
                RefreshToken = resp.RefreshToken
            });

            return resp;
        }

        public void LogOut(int id)
        {
            accountTokens.RemoveAll(at => at.AccountId == id);
        }
    }
}
