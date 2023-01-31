using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Inquiry:BaseEntity
    {
        public long Id { get; set; }
        public int propertyid { get; set; }
        public int owenerid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime schedualdate { get; set; }
    }
}
