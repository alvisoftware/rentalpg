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
    public class RentMasterService:IRentMasterService<RentMaster>
    {
        private readonly IRentMasterRepository<RentMaster> _rentMaster;
        public RentMasterService(IRentMasterRepository<RentMaster> rentMaster)
        {
            _rentMaster = rentMaster;
        }

        public void Insert(RentMaster entity)
        {
            try
            {
                if (entity != null)
                {
                    _rentMaster.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
