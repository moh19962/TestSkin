using Data;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class RegisterLogic
    {
        private IRegisterContext registercontext = new RegisterContext();

        public void RegisterUser(string Name, string LastName, string Email, string Password, int Role)
        {
            registercontext.RegisterUser(Name, LastName, Email, Password, Role);
        }
    }
}
