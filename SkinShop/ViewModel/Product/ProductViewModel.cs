using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.Product
{
    public class ProductViewModel
    {
        public int ProductType { get; set; }
        public string Description { get; set; }
        public Model.Product product { get; set; }
        //public List<Model.Product> Products { get; set; } = new List<Model.Product>();
        public IFormFile Image { get; set; }

        public ProductViewModel() { }

        public ProductViewModel(int productType)
        {
            product = new Model.Product();
            ProductType = productType;
        }
    }
}
