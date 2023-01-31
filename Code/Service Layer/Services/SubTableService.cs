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
    public class SubTableService : ISubTableService<Subtable>
    {
        private readonly ISubTableRepository<Subtable> _subTableRepository;
        public SubTableService(ISubTableRepository<Subtable> subTableRepository)
        {
            _subTableRepository = subTableRepository;
        }

        public IEnumerable<Subtable> GetAll()
        {
            try
            {
                return _subTableRepository.GetAll();
            }
            catch(Exception) 
            {
                throw;
                return null;
            }
        }

        public void insert(Subtable subtable)
        {
            try
            {
                if (subtable != null)
                {
                    _subTableRepository.Insert(subtable);
                }
            }
            catch(Exception) 
            {
                throw;
            }
        }
    }
}
