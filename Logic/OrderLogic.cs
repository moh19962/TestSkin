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
    }
}
