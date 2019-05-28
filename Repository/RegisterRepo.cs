using Data;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RegisterRepo
    {
        private readonly IRegisterContext _registercontext;

        public RegisterRepo(IRegisterContext context)
        {
            _registercontext = context;
        }

        public RegisterRepo()
        {
            _registercontext = new RegisterContext();
        }
        public void RegisterUser(string Name, string LastName, string Email, string Password, int Role)
        {
            _registercontext.RegisterUser(Name, LastName, Email, Password, Role);
        }
    }
}
