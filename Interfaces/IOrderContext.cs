using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IOrderContext
    {
        void PlaceOrder(Order order);
        Order GetOrder(int userId);
        List<Order> GetOrderList(int userId);
        void DeletCartTable(Order order);
    }
}
