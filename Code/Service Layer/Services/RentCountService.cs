using DomainLayer.Models;
using RepositoryLayer.CustomeModel;
using RepositoryLayer.IRepository;
using RepositoryLayer.Model;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class RentCountService : IRentCountService<RentCountModel>
    {
        private readonly IRentCountRepository<RentCountModel> _rentCountRepository;
        public RentCountService(IRentCountRepository<RentCountModel> rentCountRepository)
        {
            _rentCountRepository = rentCountRepository;
        }

        public void AddRent(List<RentDetails> listofrentdetails)
        {
            _rentCountRepository.AddRentDetails(listofrentdetails);
        }

        public List<RentCountModel> GetRentCounts(RentCountModel rentCountModel)
        {
            try
            {
                return _rentCountRepository.RentCalculation(rentCountModel);
            }
            catch (Exception)
            {
                throw;
                return null;
            }
        }
    }
}
