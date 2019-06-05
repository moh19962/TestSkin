using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;
using SkinShop.ViewModel.User;

namespace SkinShop.Controllers
{
    public class AdminController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        ProfileViewModel profileViewModel = new ProfileViewModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminList()
        {
            profileViewModel.AdminList = userLogic.GetAdmins();
            return View(profileViewModel);
        }

        [HttpPost]
        public IActionResult DeleteAdmin(int userId)
        {
            userLogic.DeleteAdmin(userId);
            return RedirectToAction("AdminList");
        }
    }
}