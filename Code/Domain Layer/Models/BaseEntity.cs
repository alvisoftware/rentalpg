using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class BaseEntity
    {
        [Key]
        public long id { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime deleteddate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; } = false;
    }
}
