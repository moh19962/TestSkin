using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IProductContext
    {
        void AddProduct(Product product);
        void AddToWishList(int productId, int userId, int amount);
        List<Product> GetProducts();
        List<Product> GetWishList(int userId);
        int CheckProductID(int productId, int userId);
        void UpdateAmount(int cartId, int amount);
        Product GetProductById(int productId);
        void EditProduct(Product product);
        void DeleteProduct(int productId);
    }
}
