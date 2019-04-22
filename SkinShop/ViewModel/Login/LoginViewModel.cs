using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.Login
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public LoginViewModel() { }

        public LoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
