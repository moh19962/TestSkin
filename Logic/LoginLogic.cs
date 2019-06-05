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
        private ILoginContext loginContext = new LoginContext();

        public User LoginCheck(string email, string userPass)
        {
            User user = loginContext.GetUser(email);
            if (email == user.Email && userPass == user.Password)
                return user;
            else
                return null;
        }
    }
}
