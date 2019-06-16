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

        [HttpPost]
        public IActionResult AddToCart(ProductSpecificationViewModel viewModel, int productId)
        {
            var amount = viewModel.Product.Amount;
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _cartLogic.AddToCart(productId, userId, amount);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult Cart()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _cartViewModel.cart = _cartLogic.GetProductsFromCart(userId);
            return View(_cartViewModel);
        }


        public IActionResult DeleteProductFromCart(int productId)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _cartLogic.DeleteProductFromCart(userId, productId);
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