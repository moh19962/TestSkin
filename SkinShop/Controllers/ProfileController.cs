using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using SkinShop.ViewModel.User;

namespace SkinShop.Controllers
{
    public class ProfileController : Controller
    {
        private UserLogic userlogic = new UserLogic();
        ProfileViewModel viewModel = new ProfileViewModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            viewModel.User = userlogic.GetUser(userId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel viewModel)
        {
            var data = viewModel.User;

            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            userlogic.UpdateUser(data, userId);

            return View(viewModel);
        }
    }
}