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
    public class RentTableService:IRentTableService<RentTable>
    {
        private readonly IRentTableRepository<RentTable> _rentTable;
        public RentTableService(IRentTableRepository<RentTable> rentTable)
        {
            _rentTable = rentTable;
        }
        public void Insert(RentTable entity)
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
