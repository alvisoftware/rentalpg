using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class RentMaster:BaseEntity
    {
        public long ownerid { get; set; }
        [ForeignKey("ownerid")]
        public virtual Owners Owners { get; set; }
        public long propertyid { get; set; }
        [ForeignKey("propertyid")]
        public virtual PropertyInfo PropertyInfo { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string amount { get; set; }
    }
}
