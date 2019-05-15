using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UserLogic
    {
        private IUserContext usercontext = new UserContext();

        public User GetUser(int UserID)
        {
            User user = usercontext.GetUser(UserID);

            return user;
        }
        public void UpdateUser(User account, int userID)
        {
            usercontext.UpdateUser(account, userID);
        }

        //Admin
        public List<User> getAdmins()
        {
            List<User> adminList = usercontext.getAdmins();
            return adminList;
        }
        public void DeleteAdmin(int UserID)
        {
            usercontext.DeleteAdmin(UserID);
        }
    }


}
