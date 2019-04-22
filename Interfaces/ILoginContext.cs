using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ILoginContext
    {
        User GetUser(string email);
        void LoginUser(string Name, string LastName);
    }
}
