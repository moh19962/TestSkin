﻿using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    public class FakeDatabaseProduct 
    {
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public Cart GetProducts()
        {
            Cart cart = new Cart();

            cart.Products = new List<Product>();

            Product product = new Product();
            product.ProductID = 1;
            product.Productname = "Ninja";
            product.Productprice = 7;

            Product product1 = new Product();
            product1.ProductID = 9;
            product1.Productname = "Tristana";
            product1.Productprice = 7;

            Product product2 = new Product();
            product2.ProductID = 3;
            product2.Productname = "asznee";
            product2.Productprice = 7;

            cart.Products.Add(product);
            cart.Products.Add(product1);
            cart.Products.Add(product2);
            return cart;

        }

        //public List<Product> GetProducts()
        //{
        //    List<Product> prodList = new List<Product>();

        //    Product product = new Product();
        //    product.ProductID = 1;
        //    product.Productname = "Ninja";
        //    product.Productprice = 7;

        //    Product product1 = new Product();
        //    product1.ProductID = 2;
        //    product1.Productname = "Tristana";
        //    product1.Productprice = 7;

        //    Product product2 = new Product();
        //    product2.ProductID = 3;
        //    product2.Productname = "asznee";
        //    product2.Productprice = 7;

        //    prodList.Add(product);
        //    prodList.Add(product1);
        //    prodList.Add(product2);
        //    return prodList;

        //}
        public Product GetProductByID(int productId)
        {
            throw new NotImplementedException();
        }
        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
