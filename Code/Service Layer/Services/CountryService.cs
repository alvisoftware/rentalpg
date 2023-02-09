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
    public class CountryService : ICountryService<CountryTable>
    {
        private readonly ICountryRepository<CountryTable> _countryRepository;
        public CountryService(ICountryRepository<CountryTable> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IEnumerable<CountryTable> GetAll()
        {
            return _countryRepository.GetAll();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
