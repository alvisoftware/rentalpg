using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static DomainLayer.Models.PropertyInfo;
//using static DomainLayer.Models.PropertyInfo;

namespace RepositoryLayer.CustomeModel
{
    public class OwnerBackendModel
    {
        public long pid{get; set; }
        public long oid { get; set; }
        public string name { get;set; }
        public int noofproperty { get;set; }
        public string availableproperty { get;set; }
        public transtype remainproperty { get; set; }
    }
}
