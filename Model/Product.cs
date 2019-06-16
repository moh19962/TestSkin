using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Productname { get; set; }
        public double Productprice { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public double SubTotal { get; set; }
    }
}
