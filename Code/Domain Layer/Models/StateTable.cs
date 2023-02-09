using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class StateTable:BaseEntity
    {
        public int stateid { get; set; }
        public string statename { get; set; }
    }
}
