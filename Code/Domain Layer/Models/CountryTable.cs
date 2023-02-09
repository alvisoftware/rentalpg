using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class CountryTable:BaseEntity
    {
        public int cityid { get; set; }
        public string countryname { get; set; }
    }
}
