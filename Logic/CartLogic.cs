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

        public List<Cart> GetProductsFromCart(int userID)
        {
            List<Cart> productCartList = cartcontext.GetProductsFromCart(userID);
            foreach (Cart cart in productCartList)
            {
                cart.SubTotal = (int)Convert.ToDouble(cart.Product.Productprice * cart.Amount);
            }
            return productCartList;
        }
    }
}
