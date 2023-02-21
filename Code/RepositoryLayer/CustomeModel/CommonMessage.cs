using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CustomeModel
{
    public class CommonMessage
    {
        
        public long tenantid { get; set; }
        public long propertyid { get; set; }
        public string message { get; set; }
        public string role { get; set; }
    }
}
