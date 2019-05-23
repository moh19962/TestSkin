using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICartContext
    {
        List<Product> GetProductsFromCart(int UserId);
        void AddToCart(int productID, int userID, int Amount);
        int CheckProductID(int productID, int userID);
        void UpdateAmount(int CartID, int Amount);
        void DeleteProductFromCart(int UserID, int ProductID);
        void UpdateCart(int UserID, int ProductID, int Amount);
    }
}
