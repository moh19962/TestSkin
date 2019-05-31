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
        OrderLogic orderlogic = new OrderLogic();
        CartLogic cartLogic = new CartLogic();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Order()
        {
            int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            orderViewModel.order = orderlogic.GetOrder(userID);
            return View(orderViewModel);
        }

        //public IActionResult Order()
        //{
        //    int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
        //    orderViewModel.ProductList = orderlogic.GetOrder(userID);
        //    return View(orderViewModel);
        //}

        [Authorize]
        [HttpPost]
        public IActionResult PlaceOrder(CartViewModel viewModel)//( Winkelwagen winkelwagen)
        {
            Order order = new Order();
            order.Cart = new Cart();
            order.User.UserID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            //order.Cart.Products = viewModel.ProductList;
            order.Cart = cartLogic.GetProductsFromCart(order.User.UserID);
            orderlogic.PlaceOrder(order);
            orderlogic.DeletCartTable(order);
            return RedirectToAction("Order");
        }
    }
}