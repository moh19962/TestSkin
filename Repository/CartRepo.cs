using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CartRepo
    {
        private readonly ICartContext _cartcontext;
        public CartRepo(ICartContext context)
        {
            _cartcontext = context;
        }

        public CartRepo()
        {
            _cartcontext = new CartContext();
        }


        //public Cart GetProductsFromCart(int userID)
        //{
        //    Cart cart = new Cart();

        //    cart.Products = _cartcontext.GetProductsFromCart(userID);

        //    foreach (Product product in cart.Products)
        //    {
        //        product.SubTotal = (int)Convert.ToDouble(product.Productprice * product.Amount);

        //    }
        //    return cart;
        //}

        public Cart GetProductsFromCart(int userID)
        {
            Cart cart = new Cart();

            cart.Products = _cartcontext.GetProductsFromCart(userID);

            return cart;
        }

        //public Cart GetProductsFromCart(int userID)
        //{
        //    Cart cart = new Cart();

        //    cart.Products = _cartcontext.GetProductsFromCart(userID);

        //    return cart;
        //}

        public void AddToCart(int ProductID, int UserID, int Amount)
        {
            int productInCartID = _cartcontext.CheckProductID(ProductID, UserID);
            if (productInCartID != 0)
            {
                _cartcontext.UpdateAmount(productInCartID, Amount);
            }
            else
            {
                _cartcontext.AddToCart(ProductID, UserID, Amount);
            }
        }

        public void DeleteProductFromCart(int UserID, int ProductID)
        {
            _cartcontext.DeleteProductFromCart(UserID, ProductID);
        }
        public void UpdateCart(int UserID, int ProductID, int Amount)
        {
            _cartcontext.UpdateCart(UserID, ProductID, Amount);
        }

    }
}
