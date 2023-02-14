using DomainLayer.Models;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repository;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class CityService:ICityService<CityModel>
    {
        private readonly ICityRepository<CityModel> _cityRepository;
        public CityService(ICityRepository<CityModel> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<CityModel> GetAll()
        {
            return _cityRepository.GetAll();
        }
    }
}
