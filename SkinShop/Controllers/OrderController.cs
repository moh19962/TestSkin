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
        CartViewModel cartViewModel = new CartViewModel();
        OrderLogic orderlogic = new OrderLogic();
        CartLogic cartLogic = new CartLogic();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Order()
        {
            int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            orderViewModel.ProductList = orderlogic.GetOrders(userID);
            return View(orderViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult PlaceOrder(CartViewModel viewModel)//( Winkelwagen winkelwagen)
        {
            //int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            Order order = new Order();
            order.Cart = new Cart();
            order.Cart.Products = viewModel.ProductList;
            orderlogic.PlaceOrder(order);
            return RedirectToAction("Order");
        }


        //public IActionResult PlaceOrder(CartViewModel viewModel)//( Winkelwagen winkelwagen)
        //{
        //    int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
        //    cartViewModel.ProductList = cartLogic.GetProductsFromCart(userId);
        //    List<Product> order = viewModel.ProductList;
        //    orderlogic.PlaceOrder(order, userId);
        //    return RedirectToAction("Order");
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