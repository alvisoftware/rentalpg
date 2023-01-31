using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Model
{
    public class PropertyModel
    {
        public long pid { get; set; }
        public long oid { get; set; }
        public string? title { get; set; }
        public string? owner { get; set; }
        public DateTime date { get; set; }
    }
}
