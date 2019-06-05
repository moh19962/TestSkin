using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IProductContext
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        void EditProduct(Product product);
        void DeleteProduct(int productId);
    }
}
