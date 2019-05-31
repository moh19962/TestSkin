using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IOrderContext
    {
        void PlaceOrder(Order order);
        //void PlaceOrder(Order cart, int UserId);
        List<Product> GetOrder(int UserId);
        void DeletCartTable(Order order);
    }
}
