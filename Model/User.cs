using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
