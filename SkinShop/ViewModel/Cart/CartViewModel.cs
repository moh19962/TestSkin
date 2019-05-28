using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.Cart
{
    public class CartViewModel
    {
        public List<Model.Cart> Cart { get; set; } = new List<Model.Cart>();
        public List<Model.Product> ProductList { get; set; } = new List<Model.Product>();
        public Model.Cart cart { get; set; }
        public CartViewModel cartViewModel {get; set;} 

        public CartViewModel()
        {
            Cart = new List<Model.Cart>();
        }
    }
}
