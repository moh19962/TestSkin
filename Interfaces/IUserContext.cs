using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserContext
    {
        User GetUser(int userId);
        void UpdateUser(User account, int userId);
        List<User> GetAdmins();
        void DeleteAdmin(int userId);
    }
}
