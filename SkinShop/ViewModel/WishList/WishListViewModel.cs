using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.WishList
{
    public class WishListViewModel
    {
        public List<Model.Product> Cart { get; set; } = new List<Model.Product>();

    }
}