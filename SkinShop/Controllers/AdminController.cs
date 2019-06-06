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
        private readonly UserLogic _userLogic = new UserLogic();
        readonly ProfileViewModel _profileViewModel = new ProfileViewModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminList()
        {
            _profileViewModel.AdminList = _userLogic.GetAdmins();
            return View(_profileViewModel);
        }

        [HttpPost]
        public IActionResult DeleteAdmin(int userId)
        {
            _userLogic.DeleteAdmin(userId);
            return RedirectToAction("AdminList");
        }
    }
}