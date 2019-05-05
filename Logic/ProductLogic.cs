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

        public Product GetProductByID(int productID)
        {
            return productcontext.GetProductByID(productID);

        }

        //public List<Product> GetCurrentProduct(int productID)
        //{
        //    List<Product> ProductList = productcontext.GetCurrentProduct(productID);
        //    return ProductList;
        //}

        public void AddProduct(Product product)
        {
            productcontext.AddProduct(product);
        }

        //public List<Product> ProductSpecifications(int productID)
        //{
        //    List<Product> CurrentProductSpecList = productcontext.ProductSpecifications(productID);
        //    return CurrentProductSpecList;
        //}


    }
}