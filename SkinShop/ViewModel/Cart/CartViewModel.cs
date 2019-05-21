using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.Cart
{
    public class CartViewModel
    {
        public Model.Product Product { get; set; } = new Model.Product();
        public List<Model.Product> Producten = new List<Model.Product>();
        public List<Model.Cart> Cart { get; set; } = new List<Model.Cart>();
        public List<Model.Cart> CartList { get; set; } = new List<Model.Cart>();
        public List<Model.Cart> Carts { get; set; } = new List<Model.Cart>();
        public List<Order> OrderList { get; set; } = new List<Order>();
        public Model.Cart cart { get; set; } = new Model.Cart();
        //public Model.Order order { get; set; } = new Model.Order();


        public CartViewModel()
        {
            Cart = new List<Model.Cart>();
            Carts = new List<Model.Cart>();
        }
    }
}
