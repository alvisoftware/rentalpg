using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Tenant:BaseEntity
    {
        //public long id { get; set; }
        public string firsttname { get; set; }
        public string lasttname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
    }
}
