using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    class FakeDatabase : IUserContext
    {
        public User GetUser(int UserID)
        {
            if (UserID == 1)
            {
                User user = new User();
                user.UserID = 1;
                user.Name = "Moo";
                user.Lastname = "Parwani";
                user.Password = "test";
                user.RoleId = 1;
                return user;
            }
            else
            {
                User user = new User();
                user.UserID = 2;
                user.Name = "Thomas";
                user.Lastname = "van der Pol";
                user.Password = "pass";
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
