using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PropertyType:BaseEntity
    {
        public long id { get; set; }
        public string name { get; set; }
    }
}
