using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class MesssageDetails:BaseEntity
    {
        public long messagemasterid { get; set; }
        [ForeignKey("messagemasterid")]
        public virtual MessageMaster MessageMaster { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public string replyby { get; set; }
    }
}
