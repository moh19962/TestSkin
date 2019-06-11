using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;
using SkinShop.ViewModel.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using SkinShop.ViewModel.Cart;
using Microsoft.AspNetCore.Authorization;

namespace SkinShop.Controllers
{
    public class ProductController : Controller
    {
        readonly ProductSpecificationViewModel _productSpecificatie = new ProductSpecificationViewModel();

        private readonly ProductLogic _productLogic = new ProductLogic();
        private readonly IHostingEnvironment _hostingEnvironment;

        public IActionResult Index()
        {
            return View();
        }

        public ProductController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IActionResult Products()
        {
            _productSpecificatie.Products = _productLogic.GetProducts();
            return View(_productSpecificatie);
        }

        public IActionResult WishList()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _productSpecificatie.WishListProducts = _productLogic.GetWishList(userId);
            return View(_productSpecificatie);
        }

        [HttpPost]
        public IActionResult AddToWishList(ProductSpecificationViewModel viewModel, int productId)
        {
            var amount = viewModel.Product.Amount;
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            _productLogic.AddToWishList(productId, userId, amount);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult CurrentProduct(int productId)
        {
            _productSpecificatie.Product = _productLogic.GetProductById(productId);
            return View(_productSpecificatie);
        }

        [Authorize]
        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel viewModel)
        {
            var products = viewModel.product;
            var productImage = viewModel.Image;
            string productImageFileName = productImage.FileName;
            products.Images = productImageFileName;


            _productLogic.AddProduct(products);
            //Add image to root of app
            string mapRoot = "images/";

            var productImagePath = Path.Combine(_hostingEnvironment.WebRootPath, mapRoot);
            await AddFileToDirectory(productImage, productImagePath);

            return RedirectToAction("AddProduct");
        }

        public async Task AddFileToDirectory(IFormFile file, string path)
        {
            if (file.Length > 0)
            {
                try
                {
                    var filePath = Path.Combine(path, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);

                    }
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(path);

                    await AddFileToDirectory(file, path);
                }
            }
            else
            {
                throw new Exception("File is leeg");
            }
        }

        [Authorize]
        //ProductWijzigen/Verwijderen
        public IActionResult ProductManagment()
        {
            _productSpecificatie.Products = _productLogic.GetProducts();

            return View(_productSpecificatie);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            _productLogic.DeleteProduct(productId);

            return RedirectToAction("ProductManagment");
        }

        [Authorize]
        //Update product pagina
        public IActionResult UpdateProduct(ProductSpecificationViewModel viewModel, int productId)
        {
            _productSpecificatie.Product = _productLogic.GetProductById(productId);
            return View(_productSpecificatie);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductSpecificationViewModel viewModel, int productId)
        {
            var products = viewModel.Product;
            _productLogic.EditProduct(products);

            return RedirectToAction("ProductManagment");
        }
    }
}