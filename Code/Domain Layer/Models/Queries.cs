using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Queries : BaseEntity
    {
        public long tenantid { get; set; }
        public long propertyid { get; set; }
        //public string message { get; set; }
        public string status { get; set; }
    }
}
