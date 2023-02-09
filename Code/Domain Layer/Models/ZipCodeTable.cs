using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ZipCodeTable:BaseEntity
    {
        public int zipid { get; set; }
        public string zipcode { get; set; }
    }
}
