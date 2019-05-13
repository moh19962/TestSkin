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
        CartLogic cartLogic = new CartLogic();

        CartViewModel cartViewModel = new CartViewModel();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(ProductSpecificationViewModel viewModel, int ProductID)
        {
            var Amount = viewModel.Product.Amount;
            int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            cartLogic.AddToCart(ProductID, UserID, Amount);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult Cartz()
        {
            int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            cartViewModel.Cart = cartLogic.GetProductsFromCart(userID);
            return View(cartViewModel);
        }

        public IActionResult DeleteProductFromCart(int ProductID)
        {
            int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            cartLogic.DeleteProductFromCart(UserID, ProductID);
            return RedirectToAction("Cartz", "Cart");
        }

        public IActionResult UpdateCart(int ProductID, int Amount)
        {
            int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            //int Amount = cartViewModel.cart.Amount;
            cartLogic.UpdateCart(UserID, ProductID, Amount);
            return RedirectToAction("Cartz", "Cart");
        }
    }
}