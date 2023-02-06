using Domain_Layer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class RentMaster : BaseEntity
    {
        public long ownerid { get; set; }
        [ForeignKey("ownerid")]
        public virtual Owners Owners { get; set; }
        public long propertyid { get; set; }
        [ForeignKey("propertyid")]
        public virtual PropertyInfo PropertyInfo { get; set; }
        public long tenantid { get; set; }
        [ForeignKey("tenantid")]
        public virtual Tenant Tenant { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string amount { get; set; }
    }
}
