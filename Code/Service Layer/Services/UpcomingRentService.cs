using DomainLayer.Models;
using RepositoryLayer.IRepository;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class UpcomingRentService : IUpcomingRentService<RentSchedules>
    {
        private readonly IUpcomingRentRepository<RentSchedules> _upcomingRent;
        public UpcomingRentService(IUpcomingRentRepository<RentSchedules> upcomingRent)
        {
            _upcomingRent = upcomingRent;
        }

        public List<RentSchedules> GetUpcomingRent()
        {
            return _upcomingRent.GetUpcomingRentList();
        }
    }
}
