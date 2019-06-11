using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepo
    {
        private readonly IProductContext _productContext;
        public ProductRepo(IProductContext context)
        {
            _productContext = context;
        }

        public ProductRepo()
        {
            _productContext = new ProductContext();
        }

        public List<Product> GetProducts()
        {
            List<Product> productList = _productContext.GetProducts();
            return productList;
        }

        public List<Product> GetWishList(int userId)
        {
            List<Product> wishList = _productContext.GetWishList(userId);
            return wishList;
        }
        //public void AddToCart(int productId, int userId, int amount)
        //{
        //    int productInCartId = _productContext.CheckProductID(productId, userId);
        //    if (productInCartId != 0)
        //    {
        //        _productContext.UpdateAmount(productInCartId, amount);
        //    }
        //    else
        //    {
        //        _productContext.AddToWishList(productId, userId, amount);
        //    }
        //}

        public Product GetProductById(int productId)
        {
            return _productContext.GetProductById(productId);

        }

        public void AddProduct(Product product)
        {
            _productContext.AddProduct(product);
        }

        public void EditProduct(Product product)
        {
            _productContext.EditProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            _productContext.DeleteProduct(productId);
        }
    }
}
