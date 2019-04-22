using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class LoginLogic
    {
        private ILoginContext logincontext = new LoginContext();

        public User LoginCheck(string email, string userpass)
        {
            User user = logincontext.GetUser(email);
            if (email == user.Email && userpass == user.Password)
                return user;
            else
                return null;
        }
    }
}
