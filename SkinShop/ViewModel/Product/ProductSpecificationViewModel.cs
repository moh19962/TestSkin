using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.Product
{
    public class ProductSpecificationViewModel
    {
        public List<Model.Product> Products { get; set; } = new List<Model.Product>();
        public List<Model.Product> WishListProducts { get; set; } = new List<Model.Product>();
        public Model.Product Product { get; set; } = new Model.Product();
    }
}
