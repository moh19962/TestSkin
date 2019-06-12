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
        readonly OrderViewModel _orderViewModel = new OrderViewModel();
        readonly OrderLogic _orderLogic = new OrderLogic();
        readonly CartLogic _cartLogic = new CartLogic();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _orderViewModel.order = _orderLogic.GetOrder(userId);
            return View(_orderViewModel);
        }

        public IActionResult OrderList()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _orderViewModel.OrderList = _orderLogic.GetOrderList(userId);
            return View(_orderViewModel);
        }


        [Authorize]
        [HttpPost]
        public IActionResult PlaceOrder(CartViewModel viewModel)
        {
            Order order = new Order();
            order.Cart = new Cart();
            order.User.UserID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            order.Cart = _cartLogic.GetProductsFromCart(order.User.UserID);
            _orderLogic.PlaceOrder(order);
            _orderLogic.DeletCartTable(order);
            return RedirectToAction("Order");
        }

        [Authorize]
        public IActionResult PayMethod()
        {
            return View("PayMethod");
        }
    }
}