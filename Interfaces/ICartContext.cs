using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICartContext
    {
        List<Cart> GetProductsFromCart(int UserId);
    }
}
