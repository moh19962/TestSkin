using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.Order
{
    public class OrderViewModel
    {
        public List<Model.Order> OrderList { get; set; } = new List<Model.Order>();
        public Model.Order order { get; set; }

    }
}
