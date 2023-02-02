using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CustomeModel
{
    public class RentModel
    {
        public string ownername { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        //public string propertyname { get; set; }
        public string payamount { get; set; }
    }
}
