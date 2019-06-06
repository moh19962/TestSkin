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
        private readonly ICartContext _cartContext = new CartContext();

        public Cart GetProductsFromCart(int userId)
        {
            Cart cart = new Cart();

            cart.Products = _cartContext.GetProductsFromCart(userId);
            
            foreach (Product product in cart.Products)
            {
                product.SubTotal = (int)Convert.ToDouble(product.Productprice * product.Amount);

            }
            return cart;
        }

        public void AddToCart(int productId, int userId, int amount)
        {
            int productInCartId = _cartContext.CheckProductID(productId, userId);
            if (productInCartId != 0)
            {
                _cartContext.UpdateAmount(productInCartId, amount);
            }
            else
            {
                _cartContext.AddToCart(productId, userId, amount);
            }
        }

        public void DeleteProductFromCart(int userId, int productId)
        {
            _cartContext.DeleteProductFromCart(userId, productId);
        }
        public void UpdateCart(int userId, int productId, int amount)
        {
            _cartContext.UpdateCart(userId, productId, amount);
        }
        public void DeleteCart(int userId)
        {
            _cartContext.DeleteCart(userId);
        }
    }
}
