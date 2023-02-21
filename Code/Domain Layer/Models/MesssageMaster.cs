using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class MesssageMaster:BaseEntity
    {
        public long propertyid{ get; set; }
        [ForeignKey("propertyid")]
        public virtual PropertyInfo PropertyInfo { get; set; }
        public long tenantid { get; set; }
        [ForeignKey("tenantid")]
        public virtual Tenant Tenant { get; set; }
    }
}
