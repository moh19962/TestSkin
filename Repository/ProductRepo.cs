using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepo
    {
        private readonly IProductContext _productcontext;
        public ProductRepo(IProductContext context)
        {
            _productcontext = context;
        }

        public ProductRepo()
        {
            _productcontext = new ProductContext();
        }

        public List<Product> GetProducts()
        {
            List<Product> ProductList = _productcontext.GetProducts();
            return ProductList;
        }

        public Product GetProductByID(int productID)
        {
            return _productcontext.GetProductByID(productID);

        }

        public void AddProduct(Product product)
        {
            _productcontext.AddProduct(product);
        }

        public void EditProduct(Product product)
        {
            _productcontext.EditProduct(product);
        }

        public void DeleteProduct(int productID)
        {
            _productcontext.DeleteProduct(productID);
        }
    }
}
