using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICartContext
    {
        List<Product> GetProductsFromCart(int userId);
        void AddToCart(int productId, int userId, int amount);
        int CheckProductID(int productId, int userId);
        void UpdateAmount(int cartId, int amount);
        void DeleteProductFromCart(int userId, int productId);
        void DeleteCart(int userId);
        void UpdateCart(int userId, int productId, int amount);
    }
}
