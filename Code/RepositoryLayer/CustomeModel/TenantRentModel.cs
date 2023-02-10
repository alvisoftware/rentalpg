using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CustomeModel
{
    public class TenantRentModel
    {
        public string propertyname { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string rentamount { get; set; }
        public string status { get; set; }
    }
}
