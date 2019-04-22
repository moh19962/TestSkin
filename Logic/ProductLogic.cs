using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ProductLogic
    {
        private IProductContext productcontext = new ProductContext();

        public List<Product> GetProducts()
        {
            List<Product> ProductList = productcontext.GetProducts();
            return ProductList;
        }

        public void AddProduct(Product product)
        {
            productcontext.AddProduct(product);
        }
    }
}