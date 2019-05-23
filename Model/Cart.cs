using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Cart
    {
        public int CartID { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public int Amount { get; set; }
        public int SubTotal { get; set; }
        public DateTime Date { get; set; }

        public Cart()
        {
            Product = new Product();
        }
    }
}
