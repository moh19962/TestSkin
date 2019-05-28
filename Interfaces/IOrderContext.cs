using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IOrderContext
    {
        //void PlaceOrder(List<Product> cartProducts, int UserId);
        void PlaceOrder(Order order);
        //void PlaceOrder(Order cart, int UserId);
        List<Product> GetOrders(int UserId);
    }
}
