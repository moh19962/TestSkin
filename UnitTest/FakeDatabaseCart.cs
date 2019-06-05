using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    class FakeDatabaseCart : ICartContext
    {
        public List<Product> GetProductsFromCart(int userID)
        {
            List<Product> CartList = new List<Product>();
            Product product = new Product();
            product.ProductID = 3;
            product.Productname = "Ninja";
            product.Productprice = 7;
            product.Amount = 3;

            Product product1 = new Product();
            product1.ProductID = 3;
            product1.Productname = "Ninja";
            product1.Productprice = 7;
            product1.Amount = 3;

            Product product2 = new Product();
            product2.ProductID = 3;
            product2.Productname = "Ninja";
            product2.Productprice = 7;
            product2.Amount = 3;

            CartList.Add(product);
            CartList.Add(product1);
            CartList.Add(product2);
            return CartList;

        }
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
