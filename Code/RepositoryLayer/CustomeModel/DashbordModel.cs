using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CustomeModel
{
    public class DashbordModel
    {
        public int property { get; set; }
        public int avilable { get; set; }
        public int rent { get; set; }
        public List<RentSchedules> upcomingrent { get; set; }
    }
}
