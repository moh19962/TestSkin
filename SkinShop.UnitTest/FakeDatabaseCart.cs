using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    class FakeDatabaseCart
    {
        public Cart GetProductsFromCart(int userId)
        {
            Cart cart = new Cart();
            
            cart.Products = new List<Product>();

            if (userId == 1)
            {
                Product product = new Product();
                cart.User.UserID = userId;
                product.ProductID = 1;
                product.Productname = "Ninja";

                Product product1 = new Product();
                cart.User.UserID = userId;
                product1.ProductID = 1;
                product1.Productname = "Ninja";

                cart.Products.Add(product);
                cart.Products.Add(product1);
                return cart;
            }
            else
            {
                Product product = new Product();
                cart.User.UserID = userId;
                product.ProductID = 2;
                product.Productname = "Binja";

                Product product1 = new Product();
                cart.User.UserID = userId;
                product1.ProductID = 2;
                product1.Productname = "Binja";

                cart.Products.Add(product);
                cart.Products.Add(product1);
                return cart;
            }
        }

        public Cart GetSubTotal(int productPrice, int amount)
        {
            Cart cart = new Cart();

            cart.Products = new List<Product>();

                Product product = new Product();
                cart.User.UserID = 1;
                product.ProductID = 1;
                product.Productname = "Ninja";
                product.Productprice = productPrice;
                product.Amount = amount;

                cart.Products.Add(product);

                foreach (Product products in cart.Products)
                {
                    products.SubTotal = (int)Convert.ToDouble(products.Productprice * products.Amount);

                }
            return cart;
        }

        //public Cart GetProductsFromCart(int userId)
        //{
        //    Cart cart = new Cart();

        //    cart.Products = new List<Product>();

        //    Product product = new Product();
        //    product.ProductID = 1;
        //    product.Productname = "Ninja";
        //    product.Productprice = 7;
        //    cart.User.UserID = userId;

        //    Product product1 = new Product();
        //    product1.ProductID = 2;
        //    product1.Productname = "Tristana";
        //    product1.Productprice = 7;

        //    Product product2 = new Product();
        //    product2.ProductID = 3;
        //    product2.Productname = "asznee";
        //    product2.Productprice = 7;

        //    cart.Products.Add(product);
        //    cart.Products.Add(product1);
        //    cart.Products.Add(product2);
        //    return cart;
        //}
        public void AddToCart(int productID, int userID, int Amount)
        {
            throw new NotImplementedException();
        }
        public int CheckProductID(int productID, int userID)
        {
            throw new NotImplementedException();
        }
        public void UpdateAmount(int CartID, int Amount)
        {
            throw new NotImplementedException();
        }
        public void DeleteProductFromCart(int UserID, int ProductID)
        {
            throw new NotImplementedException();
        }
        public void DeleteCart(int UserID)
        {
            throw new NotImplementedException();
        }
        public void UpdateCart(int UserID, int ProductID, int Amount)
        {
            throw new NotImplementedException();
        }
    }
}
