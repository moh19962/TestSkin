using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UserRepo
    {
        private readonly IUserContext _usercontext;
        public UserRepo(IUserContext context)
        {
            _usercontext = context;
        }

        public UserRepo()
        {
            _usercontext = new UserContext();
        }

        public User GetUser(int userID)
        {
            return _usercontext.GetUser(userID);
        }

        public void UpdateUser(User account, int userID)
        {
             _usercontext.UpdateUser(account, userID);
        }
        public List<User> getAdmins()
        {
            List<User> adminList = _usercontext.getAdmins();
            return adminList;
        }

        public void DeleteAdmin(int UserID)
        {
            _usercontext.DeleteAdmin(UserID);
        }
    }
}
