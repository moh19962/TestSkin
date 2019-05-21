using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public int SubTotal { get; set; }

        public Order()
        {
            Product = new Product();
        }
    }
}
