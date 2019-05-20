using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinShop.ViewModel.Cart;

namespace SkinShop.Controllers
{
    public class OrderController : Controller
    {
        OrderLogic orderlogic = new OrderLogic();
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult PlaceOrder(CartViewModel viewModel)
        {
            var order = viewModel.cart;
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);

            orderlogic.PlaceOrder(order, userId);
            return View();
        }
    }
}