using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using SkinShop.ViewModel;
using SkinShop.ViewModel.Cart;
using SkinShop.ViewModel.Order;

namespace SkinShop.Controllers
{
    public class OrderController : Controller
    {
        OrderViewModel orderViewModel = new OrderViewModel();
        OrderLogic orderLogic = new OrderLogic();
        CartLogic cartLogic = new CartLogic();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Order()
        {
            int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            orderViewModel.order = orderLogic.GetOrder(userID);
            return View(orderViewModel);
        }


        [Authorize]
        [HttpPost]
        public IActionResult PlaceOrder(CartViewModel viewModel)
        {
            Order order = new Order();
            order.Cart = new Cart();
            order.User.UserID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            order.Cart = cartLogic.GetProductsFromCart(order.User.UserID);
            orderLogic.PlaceOrder(order);
            orderLogic.DeletCartTable(order);
            return RedirectToAction("Order");
        }

        [Authorize]
        public IActionResult PayMethod()
        {
            return View("PayMethod");
        }
    }
}