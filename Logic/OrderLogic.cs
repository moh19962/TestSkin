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
        private IOrderContext orderContext = new OrderContext();


        public void PlaceOrder(Order order)
        {
            orderContext.PlaceOrder(order);
        }


        public Order GetOrder(int userId)
        {
            Order order = new Order();

            order = orderContext.GetOrder(userId);

            foreach (Product product in order.Cart.Products)
            {
                product.SubTotal = (int)Convert.ToDouble(product.Productprice * product.Amount);
            }
            return order;
        }


        public void DeletCartTable(Order order)
        {
            orderContext.DeletCartTable(order);
        }
    }
}
