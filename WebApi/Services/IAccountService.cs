using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IAccountService
    {
        LoginResponse LogIn(string login, string password);
        void LogOut(int id);
        Account GetInfo(int id);
        LoginResponse UpdateToken(string refreshToken);
    }
}