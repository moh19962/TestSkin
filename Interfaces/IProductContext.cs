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
        //List<Product> GetCurrentProduct(int productID);
        //List<Product> ProductSpecifications(int productID);
        Product GetProductByID(int ProductID);
        void EditProduct(int ProductID, Product product);
        void DeleteProduct(int ProductID);
    }
}
