using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class UserRole:BaseEntity
    {
        //public string user { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}
