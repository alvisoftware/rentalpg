using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Subtable:BaseEntity
    {
        public virtual long messageid { get; set; }
        [ForeignKey("messageid")]
        public virtual Queries Queries { get; set; }
        public string message { get; set; }
        public long senderid { get; set; }
        public Type type { get; set; }//0 = tenant / 1 = owner
        public enum Type
        {
            tenant =0,
            owner=1
        }
    }
}
