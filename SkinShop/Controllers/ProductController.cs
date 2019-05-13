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

namespace SkinShop.Controllers
{
    public class ProductController : Controller
    {

        ProductViewModel viewModel = new ProductViewModel();
        ProductSpecificationViewModel productSpecificatie = new ProductSpecificationViewModel();

        private ProductLogic productlogic = new ProductLogic();
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
            productSpecificatie.Products = productlogic.GetProducts();
            return View(productSpecificatie);
        }

        public IActionResult CurrentProduct(int productID)
        {
            //productSpecificatie.CurrentProduct = productlogic.GetCurrentProduct(productID);
            productSpecificatie.Product = productlogic.GetProductByID(productID);
            return View(productSpecificatie);
        }

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


            productlogic.AddProduct(products);
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

        //public IActionResult Productz()
        //{
        //    productSpecificatie.Products = productlogic.GetProducts();
        //    return View(productSpecificatie);
        //}


        //ProductWijzigen/Verwijderen
        public IActionResult ProductManagment()
        {
            productSpecificatie.Products = productlogic.GetProducts();

            return View(productSpecificatie);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productID)
        {
            productlogic.DeleteProduct(productID);

            return RedirectToAction("ProductManagment");
        }

        //Update product pagina
        public IActionResult UpdateProduct(ProductSpecificationViewModel viewModel, int productID)
        {
            productSpecificatie.Product = productlogic.GetProductByID(productID);
            return View(productSpecificatie);
        }

        public IActionResult EditProduct(ProductSpecificationViewModel viewModel, int productID)
        {
            var products = viewModel.Product;
            productlogic.EditProduct(productID, products);

            return RedirectToAction("UpdateProduct");
        }

        public IActionResult DeleteProductFromCart(int ProductID)
        {
            int UserID = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value);
            productlogic.DeleteProductFromCart(UserID, ProductID);
            return RedirectToAction("Cartz", "Cart");
        }
    }
}