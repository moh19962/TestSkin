using Data;
using Interfaces;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UserLogic
    {
        private UserRepo userRepo = new UserRepo();

        public User GetUser(int userId)
        {
            User user = userRepo.GetUser(userId);

            return user;
        }
        public void UpdateUser(User account, int userId)
        {
            userRepo.UpdateUser(account, userId);
        }

        //Admin
        public List<User> GetAdmins()
        {
            List<User> adminList = userRepo.GetAdmins();
            return adminList;
        }
        public void DeleteAdmin(int userId)
        {
            userRepo.DeleteAdmin(userId);
        }
    }























    //public class UserLogic
    //{
    //    private IUserContext usercontext = new UserContext();

    //    public User GetUser(int UserID)
    //    {
    //        User user = usercontext.GetUser(UserID);

    //        return user;
    //    }
    //    public void UpdateUser(User account, int userID)
    //    {
    //        usercontext.UpdateUser(account, userID);
    //    }

    //    //Admin
    //    public List<User> getAdmins()
    //    {
    //        List<User> adminList = usercontext.getAdmins();
    //        return adminList;
    //    }
    //    public void DeleteAdmin(int UserID)
    //    {
    //        usercontext.DeleteAdmin(UserID);
    //    }
    //}


}
