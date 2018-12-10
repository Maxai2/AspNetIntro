using System;
using System.Collections.Generic;
using System.Linq;
using Validation.Models;

namespace Validation.Services
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>()
        {
            new User(){ Id = 1, Birthday = DateTime.Now, Email = "mail1@mail.ma", Name = "User 1", Password = "123" },
            new User(){ Id = 2, Birthday = DateTime.Now, Email = "mail2@mail.ma", Name = "User 2", Password = "123" }
        };

        public void AddUser(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
        }

        public bool CheckEmail(string email)
        {
            return users.Where(u => u.Email == email).Count() > 0;
        }

        public User GetUser(int id)
        {
            return users.Find(u => u.Id == id);
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
