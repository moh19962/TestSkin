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

        ProductSpecificationViewModel productSpecificatie = new ProductSpecificationViewModel();

        private ProductLogic productLogic = new ProductLogic();
        private IHostingEnvironment _hostingEnvironment;

        public ProductController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            productSpecificatie.Products = productLogic.GetProducts();
            return View(productSpecificatie);
        }

        public IActionResult CurrentProduct(int productId)
        {
            productSpecificatie.Product = productLogic.GetProductById(productId);
            return View(productSpecificatie);
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


            productLogic.AddProduct(products);
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
            productSpecificatie.Products = productLogic.GetProducts();

            return View(productSpecificatie);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            productLogic.DeleteProduct(productId);

            return RedirectToAction("ProductManagment");
        }

        [Authorize]
        //Update product pagina
        public IActionResult UpdateProduct(ProductSpecificationViewModel viewModel, int productId)
        {
            productSpecificatie.Product = productLogic.GetProductById(productId);
            return View(productSpecificatie);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductSpecificationViewModel viewModel, int productId)
        {
            var products = viewModel.Product;
            productLogic.EditProduct(products);

            return RedirectToAction("ProductManagment");
        }
    }
}