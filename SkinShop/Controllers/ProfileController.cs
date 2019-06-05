using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic;
using SkinShop.ViewModel.User;
using Microsoft.AspNetCore.Authorization;

namespace SkinShop.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        ProfileViewModel viewModel = new ProfileViewModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            viewModel.User = userLogic.GetUser(userId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel viewModel)
        {
            var data = viewModel.User;

            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            userLogic.UpdateUser(data, userId);

            return View(viewModel);
        }
    }
}