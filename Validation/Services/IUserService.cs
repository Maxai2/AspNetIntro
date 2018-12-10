using System.Collections.Generic;
using Validation.Models;

namespace Validation.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        bool CheckEmail(string email);
        void AddUser(User user);
        User GetUser(int id);
    }
}
