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

        public void PlaceOrder(Cart order, int UserId)
        {
            ordercontext.PlaceOrder(order, UserId);
        }

        //public void PlaceOrder(Cart order, int UserId)
        //{
        //    ordercontext.PlaceOrder(order, UserId);
        //}

        public List<Order> GetOrders(int UserId)
        {
            List<Order> OrderList = ordercontext.GetOrders(UserId);
            foreach (Order order in OrderList)
            {
                order.SubTotal = (int)Convert.ToDouble(order.Product.Productprice * order.Amount);
            }
            return OrderList;
        }
    }
}
