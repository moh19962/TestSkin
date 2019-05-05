using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Cart
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public int SubTotal { get; set; }
        public DateTime Date { get; set; }

        public Cart()
        {
            Product = new Product();
        }
    }
}
