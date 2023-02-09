using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PropertyInfo:BaseEntity
    {
        public long id { get; set; }
        public long propertytypeid { get; set; }
        public long ownerid { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public long cityid { get; set; }
        [ForeignKey("cityid")]
        public virtual CountryTable CountryTable { get; set; }
        public long stateid { get; set; }
        [ForeignKey("stateid")]
        public virtual StateTable StateTable { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string description { get; set; }
        public string specification { get; set; }
        public int bedroom { get; set; }
        public int bathroom { get; set; }
        public double area { get; set; }
        public int balcony { get; set; }
        public DateTime availabledate { get; set; }
        public transtype transtpetype { get; set; }//0 = sale / 1= etle rent
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string isapprove { get; set; }
        public string createdby { get; set; }
        public string seourl { get; set; }
        public enum transtype
        {
            sale = 0,
            rent = 1
        }
    }
}
