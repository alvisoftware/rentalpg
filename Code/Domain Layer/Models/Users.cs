using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainLayer.Models.PropertyInfo;

namespace DomainLayer.Models
{
    public class Users:BaseEntity
    {
        //public string user { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public userrole role { get; set; } /*= userrole.tenant;*/ //0=Admin /1=Owner /2=Tenant
        public enum userrole
        {
            admin=0,
            owner=1,
            tenant=2
        }
        public int relaventid { get; set; }
    }
}
