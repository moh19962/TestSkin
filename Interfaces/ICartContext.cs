﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICartContext
    {
        List<Cart> GetProductsFromCart(int UserId);
        void AddToCart(int productID, int userID, int Amount);
        int CheckProductID(int productID, int userID);
        void UpdateAmount(int CartID, int Amount);
    }
}
