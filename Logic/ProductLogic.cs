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
        private ProductRepo productRepo = new ProductRepo();
        //private IProductContext productcontext = new ProductContext();

        public List<Product> GetProducts()
        {
            List<Product> productList = productRepo.GetProducts();
            return productList;
        }

        public Product GetProductById(int productId)
        {
            return productRepo.GetProductById(productId);

        }

        //public List<Product> GetCurrentProduct(int productID)
        //{
        //    List<Product> ProductList = productcontext.GetCurrentProduct(productID);
        //    return ProductList;
        //}

        public void AddProduct(Product product)
        {
            productRepo.AddProduct(product);
        }

        public void EditProduct(Product product)
        {
            productRepo.EditProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            productRepo.DeleteProduct(productId);
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