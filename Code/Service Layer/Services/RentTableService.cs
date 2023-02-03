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
    public class RentTableService:IRentTableService<RentDetails>
    {
        private readonly IRentTableRepository<RentDetails> _rentTable;
        public RentTableService(IRentTableRepository<RentDetails> rentTable)
        {
            _rentTable = rentTable;
        }
        public void Insert(RentDetails entity)
        {
            try
            {
                if (entity != null)
                {
                    _rentTable.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
