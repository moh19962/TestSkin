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
        CartViewModel cartViewModel = new CartViewModel();
        OrderLogic orderlogic = new OrderLogic();
        CartLogic cartLogic = new CartLogic();
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Order()
        //{
        //    int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
        //    var cart = cartViewModel.ProductList;
        //    cartViewModel.ProductList = orderlogic.PlaceOrder(cart, userID);
        //    return View(cartViewModel);
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult PlaceOrder(CartViewModel viewModel)//( Winkelwagen winkelwagen)
        //{
        //    var order = viewModel.cart;
        //    int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
        //    orderlogic.PlaceOrder(order, userId);
        //    return RedirectToAction("Order");
        //}
    }
}