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
        private IOrderContext _orderContext = new OrderContext();

        public void PlaceOrder(Order order)
        {
            _orderContext.PlaceOrder(order);
        }

        public Order GetOrder(int userId)
        {
            Order order = new Order();

            order = _orderContext.GetOrder(userId);

            foreach (Product product in order.Cart.Products)
            {
                product.SubTotal = (int)Convert.ToDouble(product.Productprice * product.Amount);
            }
            return order;
        }
        public List<Order> GetOrderList(int userId)
        {
            List<Order> orderList = _orderContext.GetOrderList(userId);

            foreach (Order product in orderList)
            {
                product.Product.SubTotal = (int)Convert.ToDouble(product.Product.Productprice * product.Product.Amount);

            }
            return orderList;
        }

        public void DeletCartTable(Order order)
        {
            _orderContext.DeletCartTable(order);
        }
    }
}
