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
    public class UpcomingRentService : IUpcomingRentService<UpcomingRent>
    {
        private readonly IUpcomingRentRepository<UpcomingRent> _upcomingRent;
        public UpcomingRentService(IUpcomingRentRepository<UpcomingRent> upcomingRent)
        {
            _upcomingRent = upcomingRent;
        }

        public List<UpcomingRent> GetUpcomingRent()
        {
            return _upcomingRent.GetUpcomingRentList();
        }
    }
}
