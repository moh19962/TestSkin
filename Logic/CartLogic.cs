﻿using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class CartLogic
    {
        private ICartContext cartcontext = new CartContext();

        public List<Product> GetProductsFromCart(int userID)
        {
            List<Product> productCartList = cartcontext.GetProductsFromCart(userID);
            foreach (Product product in productCartList)
            {
                //Subtotal mag niet bij product staan. Moet bij winkelwagen staan.
                product.SubTotal = (int)Convert.ToDouble(product.Productprice * product.Amount);

            }
            return productCartList;
        }

        public void AddToCart(int ProductID, int UserID, int Amount)
        {
            int productInCartID = cartcontext.CheckProductID(ProductID, UserID);
            if (productInCartID != 0)
            {
                cartcontext.UpdateAmount(productInCartID, Amount);
            }
            else
            {
                cartcontext.AddToCart(ProductID, UserID, Amount);
            }
        }

        public void DeleteProductFromCart(int UserID, int ProductID)
        {
            cartcontext.DeleteProductFromCart(UserID, ProductID);
        }
        public void UpdateCart(int UserID, int ProductID, int Amount)
        {
            cartcontext.UpdateCart(UserID, ProductID, Amount);
        }
    }
}
