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
        private UserLogic userlogic = new UserLogic();
        ProfileViewModel profileviewModel = new ProfileViewModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminList()
        {
            profileviewModel.AdminList = userlogic.getAdmins();
            return View(profileviewModel);
        }

        [HttpPost]
        public IActionResult DeleteAdmin(int UserID)
        {
            userlogic.DeleteAdmin(UserID);
            return RedirectToAction("AdminList");
        }
    }
}