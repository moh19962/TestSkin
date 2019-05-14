using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IOrderContext
    {
        void PlaceOrder(Cart order, int UserId);
    }
}
