using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkinShop.ViewModel.Cart;
using Logic;
using Microsoft.AspNetCore.Mvc;
using SkinShop.ViewModel.Product;

namespace SkinShop.Controllers
{
    public class CartController : Controller
    {
        readonly CartLogic _cartLogic = new CartLogic();

        readonly CartViewModel _cartViewModel = new CartViewModel();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(ProductSpecificationViewModel viewModel, int ProductID)
        {
            var Amount = viewModel.Product.Amount;
            int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _cartLogic.AddToCart(ProductID, UserID, Amount);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult Cart()
        {
            int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _cartViewModel.cart = _cartLogic.GetProductsFromCart(userID);
            return View(_cartViewModel);
        }


        public IActionResult DeleteProductFromCart(int ProductID)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _cartLogic.DeleteProductFromCart(userId, ProductID);
            return RedirectToAction("Cart", "Cart");
        }
        public IActionResult DeleteCart()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _cartLogic.DeleteCart(userId);
            return RedirectToAction("Cart", "Cart");
        }
    }
}