using Data;
using Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class RegisterLogic
    {
        private RegisterRepo registerRepo = new RegisterRepo();

        public void RegisterUser(string Name, string LastName, string Email, string Password, int Role)
        {
            registerRepo.RegisterUser(Name, LastName, Email, Password, Role);
        }
    }
}
