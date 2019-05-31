using Data;
using Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class OrderLogic
    {
        private IOrderContext ordercontext = new OrderContext();


        public void PlaceOrder(Order order)
        {
            ordercontext.PlaceOrder(order);
        }

        public Order GetOrder(int UserId)
        {
            Order order = new Order();

            order.Cart.Products = ordercontext.GetOrder(UserId);

            foreach (Product product in order.Cart.Products)
            {
                product.SubTotal = (int)Convert.ToDouble(product.Productprice * product.Amount);
            }
            return order;
        }

        public void DeletCartTable(Order order)
        {
            ordercontext.DeletCartTable(order);
        }

        //public List<Product> GetOrders(int UserId)
        //{
        //    List<Product> OrderList = ordercontext.GetOrders(UserId);
        //    foreach (Product order in OrderList)
        //    {
        //        order.SubTotal = (int)Convert.ToDouble(order.Productprice * order.Amount);
        //    }
        //    return OrderList;
        //}
    }
}
