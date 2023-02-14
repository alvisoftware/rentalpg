using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class UpcomingRent
    {
        public string propertytitle { get; set; }
        public string tenantname { get; set; }
        public string rentamount { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string status { get; set; }
    }
}
