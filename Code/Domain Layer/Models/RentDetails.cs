using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class RentDetails:BaseEntity
    {
        public long rentid { get; set; }
        [ForeignKey("rentid")]
        public virtual RentMaster RentMaster { get; set; }
        public DateTime startdate { get;set; }
        public DateTime enddate { get; set; }
        public string amount { get; set; }
        public payamount payableamount { get; set; }
        public decimal discount { get; set; }
        public enum payamount
        {
            True = 0,
            False = 1,
        }
    }
}
