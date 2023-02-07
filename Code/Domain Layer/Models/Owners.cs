using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class Owners : BaseEntity
    {
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? email { get; set; }
        public string password { get; set; }
        public string? contact { get; set; }
        public string? altcontact { get; set; }
        public string? companyname { get; set; }
        public string? website { get; set; }
    }
}
