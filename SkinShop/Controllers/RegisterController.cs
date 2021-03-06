﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;
using SkinShop.ViewModel.User;

namespace SkinShop.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RegisterLogic _registerLogic = new RegisterLogic();

        public IActionResult RegisterCustomer()
        {

            int roleId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "RoleId")?.Value);

            RegisterUserViewModel viewModel = new RegisterUserViewModel(roleId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult RegisterCustomer(RegisterUserViewModel viewModel)
        {
            if (viewModel.Name != null && viewModel.LastName != null && viewModel.Email != null && viewModel.Password != null)
            {
                _registerLogic.RegisterUser(viewModel.Name, viewModel.LastName, viewModel.Email, viewModel.Password, 1);
                return RedirectToAction("Index", "home");
            }
            return View("RegisterCustomer", viewModel);
        }

        public IActionResult RegisterAdmin()
        {

            return View("RegisterAdmin");
        }

        [HttpPost]
        public IActionResult RegisterAdmin(RegisterUserViewModel viewModel)
        {
            if (viewModel != null && viewModel.LastName != null && viewModel.Email != null && viewModel.Password != null)
            {
                _registerLogic.RegisterUser(viewModel.Name, viewModel.LastName, viewModel.Email, viewModel.Password, 2);
                return RedirectToAction("Index", "home");
            }
            return View("RegisterAdmin", viewModel);
        }
    }
}