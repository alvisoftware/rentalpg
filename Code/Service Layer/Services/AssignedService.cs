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
    public class AssignedService : IAssignedService<Assigned>
    {
        private readonly IAssignedRepository<Assigned> _assignedRepository;
        public AssignedService(IAssignedRepository<Assigned> assignedRepository)
        {
            _assignedRepository = assignedRepository;
        }
        public IEnumerable<Assigned> Get()
        {
            try
            {
                return _assignedRepository.Get();
            }
            catch(Exception ) 
            {
                throw;
                return null;
            }
        }

        public void Insert(Assigned assignedProperty)
        {
            try
            {
                if (assignedProperty != null)
                {
                    _assignedRepository.Add(assignedProperty);
                    _assignedRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
