using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        //public Product Product { get; set; }
        public Cart Cart { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

        public Order()
        {
            User = new User();
            Products = new List<Product>();
            //Product = new Product();
            Cart = new Cart();
        }
    }
}
