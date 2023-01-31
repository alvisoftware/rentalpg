using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Category:BaseEntity
    {
        public long id { get; set; }
        public string name { get; set; }
        public int parentid { get; set; }
        public bool isactive { get; set; }
        public string surl { get; set; }
        public string skeyword { get; set; }
        public string sdiscription { get; set; }
        public int order { get; set; }
    }
}
