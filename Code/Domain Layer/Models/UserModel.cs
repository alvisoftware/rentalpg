using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class UserModel
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }
}
