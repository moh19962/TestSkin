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
        private readonly IUserContext _userContext;
        public UserRepo(IUserContext context)
        {
            _userContext = context;
        }

        public UserRepo()
        {
            _userContext = new UserContext();
        }

        public User GetUser(int userId)
        {
            return _userContext.GetUser(userId);
        }

        public void UpdateUser(User account, int userId)
        {
            _userContext.UpdateUser(account, userId);
        }
        public List<User> GetAdmins()
        {
            List<User> adminList = _userContext.GetAdmins();
            return adminList;
        }

        public void DeleteAdmin(int userId)
        {
            _userContext.DeleteAdmin(userId);
        }
    }
}
