using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRegisterContext
    {
        void RegisterUser(string Name, string LastName, string Email, string Password, int Role);
    }
}
