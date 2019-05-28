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

        //public void PlaceOrder(List<Product> cartProducts, int UserId)
        //{
        //    ordercontext.PlaceOrder(cartProducts, UserId);
        //}


        public void PlaceOrder(Order order)
        {
            ordercontext.PlaceOrder(order);
        }

        //public void PlaceOrder(Cart order, int UserId)
        //{
        //    ordercontext.PlaceOrder(order, UserId);
        //}

        public List<Product> GetOrders(int UserId)
        {
            List<Product> OrderList = ordercontext.GetOrders(UserId);
            foreach (Product order in OrderList)
            {
                order.SubTotal = (int)Convert.ToDouble(order.Productprice * order.Amount);
            }
            return OrderList;
        }
    }
}
