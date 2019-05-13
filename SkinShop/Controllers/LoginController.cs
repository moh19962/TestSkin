using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Model;
using SkinShop.ViewModel.Login;

namespace SkinShop.Controllers
{
    public class LoginController : Controller
    {
        private LoginLogic loginLogic = new LoginLogic();

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel viewModel)
        {
            if (viewModel.Email != null && viewModel.Password != null)
            {
                User user = loginLogic.LoginCheck(viewModel.Email, viewModel.Password);

                if (user != null)
                {
                    LogUser(user);

                    return RedirectToAction("Index", "home");

                }
            }
            return View("Login", viewModel);
        }

        private void LogUser(User account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("UserID", account.UserID.ToString()),
                new Claim(ClaimTypes.Name, account.Name),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim("Role", account.RoleId.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {

            };

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)).Wait();
        }
    }
}