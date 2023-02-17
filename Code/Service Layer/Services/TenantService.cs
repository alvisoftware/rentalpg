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
    public class TenantService : ITenantService<Tenant>
    {
        private readonly ITenantRepository<Tenant> _tenantRepository;
        public TenantService(ITenantRepository<Tenant> tenant)
        {
            _tenantRepository = tenant;
        }

        public IEnumerable<Tenant> GetAll()
        {
            try
            {
                return _tenantRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
                return null;
            }
        }

        public void insert(Tenant tenant)
        {
            try
            {
                if (tenant != null)
                {
                    _tenantRepository.insert(tenant);
                    //_tenant.SaveChanges();
                }
            }
            catch(Exception) 
            {
                throw;
            }
        }

        public IEnumerable<RentSchedules> TenantRent(long tenantId)
        {
            return _tenantRepository.GetTenantRent(tenantId);
        }
    }
}
