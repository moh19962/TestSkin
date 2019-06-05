using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    class FakeDatabase
    {
        public User GetUser(string email)
        {
            if (email == "mohammadparwani@outlook.com")
            {
                User user = new User();
                user.UserID = 1;
                user.Name = "Moo";
                user.Lastname = "Parwani";
                user.Password = "test";
                user.Email = "mohammadparwani@outlook.com";
                user.RoleId = 1;
                return user;
            }
            else
            {
                User user = new User();
                user.UserID = 2;
                user.Name = "Mauk";
                user.Lastname = "van de Beek";
                user.Password = "pass";
                user.Email = "maukvdbeek@outlook.com";
                user.RoleId = 2;
                return user;
            }
        }

        public void UpdateUser(User account, int userId)
        {
            throw new NotImplementedException();
        }
        public List<User> getAdmins()
        {
            throw new NotImplementedException();
        }
        public void DeleteAdmin(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
