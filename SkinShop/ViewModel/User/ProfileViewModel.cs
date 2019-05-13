using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkinShop.ViewModel.User
{
    public class ProfileViewModel
    {
        public Model.User User { get; set; } = new Model.User();
        public List<Model.User> AdminList { get; set; } = new List<Model.User>();
    }
}
