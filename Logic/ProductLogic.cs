using Data;
using Interfaces;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ProductLogic
    {
        private readonly ProductRepo _productRepo = new ProductRepo();
        private readonly IProductContext _productContext = new ProductContext();
        private readonly ICartContext _cartContext = new CartContext();
        //private IProductContext productcontext = new ProductContext();

        public List<Product> GetProducts()
        {
            List<Product> productList = _productRepo.GetProducts();
            return productList;
        }
        public List<Product> GetWishList(int userId)
        {
            List<Product> wishList = _productRepo.GetWishList(userId);
            return wishList;
        }
        public void AddToWishList(int productId, int userId, int amount)
        {
            int productInCartId = _productContext.CheckProductID(productId, userId);
            if (productInCartId != 0)
            {
                _productContext.UpdateAmount(productInCartId, amount);
            }
            else
            {
                _productContext.AddToWishList(productId, userId, amount);
            }
        }

        //public void AddProduct(Product product)
        //{
        //    productRepo.AddProduct(product);
        //}

        public Product GetProductById(int productId)
        {
            return _productRepo.GetProductById(productId);

        }

        //public List<Product> GetCurrentProduct(int productID)
        //{
        //    List<Product> ProductList = productcontext.GetCurrentProduct(productID);
        //    return ProductList;
        //}

        public void AddProduct(Product product)
        {
            _productRepo.AddProduct(product);
        }

        public void EditProduct(Product product)
        {
            _productRepo.EditProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _productRepo.DeleteProduct(productId);
        }








        //private IProductContext productcontext = new ProductContext();

        //public List<Product> GetProducts()
        //{
        //    List<Product> ProductList = productcontext.GetProducts();
        //    return ProductList;
        //}

        //public Product GetProductByID(int productID)
        //{
        //    return productcontext.GetProductByID(productID);

        //}

        ////public List<Product> GetCurrentProduct(int productID)
        ////{
        ////    List<Product> ProductList = productcontext.GetCurrentProduct(productID);
        ////    return ProductList;
        ////}

        //public void AddProduct(Product product)
        //{
        //    productcontext.AddProduct(product);
        //}

        //public void EditProduct(Product product)
        //{
        //    productcontext.EditProduct(product);
        //}

        //public void DeleteProduct(int productID)
        //{
        //    productcontext.DeleteProduct(productID);
        //}

    }
}