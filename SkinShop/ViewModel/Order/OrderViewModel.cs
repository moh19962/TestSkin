using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.Order
{
    public class OrderViewModel
    {
        public List<Model.Product> ProductList { get; set; } = new List<Model.Product>();
    }
}
