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
            return View(viewModel);
        }

        public IActionResult Cartz()
        {
            int userID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            cartViewModel.Cart = cartLogic.GetProductsFromCart(userID);
            return View(cartViewModel);
        }
    }
}