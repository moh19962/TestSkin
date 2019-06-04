using Data;
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

        public Cart GetProductsFromCart(int userID)
        {
            Cart cart = new Cart();

            cart.Products = cartcontext.GetProductsFromCart(userID);
            
            foreach (Product product in cart.Products)
            {
                product.SubTotal = (int)Convert.ToDouble(product.Productprice * product.Amount);

            }
            return cart;
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
        public void DeleteCart(int userID)
        {
            cartcontext.DeleteCart(userID);
        }
    }
}
