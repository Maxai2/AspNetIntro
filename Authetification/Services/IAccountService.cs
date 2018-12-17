using Authetification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authetification.Services
{
    public interface IAccountService
    {
        User SignUp(string email, string pswd);
        User SignIn(string email, string pswd);
        void SignOut();
    }
}
