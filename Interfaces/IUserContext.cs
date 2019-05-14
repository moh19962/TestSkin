using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserContext
    {
        User GetUser(int UserID);
        void UpdateUser(User account, int userId);
    }
}
