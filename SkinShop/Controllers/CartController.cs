using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killer.ViewModels.Cart;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace SkinShop.Controllers
{
    public class CartController : Controller
    {
        CartLogic cartLogic = new CartLogic();

        CartViewModel cartViewModel = new CartViewModel();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            cartViewModel.Cart = cartLogic.GetProductsFromCart(userID);
            return View(cartViewModel);
        }
    }
}