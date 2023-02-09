using DomainLayer.Models;
using RepositoryLayer.IRepository;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class ZipCodeService : IZipCodeService<ZipCodeTable>
    {
        private readonly IZipCodeRepository<ZipCodeTable> _zipCodeRepository;
        public ZipCodeService(IZipCodeRepository<ZipCodeTable> zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public IEnumerable<ZipCodeTable> GetZipCode()
        {
            return _zipCodeRepository.GetAll();
        }
    }
}
