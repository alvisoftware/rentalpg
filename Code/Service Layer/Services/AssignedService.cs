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
    public class AssignedService : IAssignedService<AssignedProperties>
    {
        private readonly IAssignedRepository<AssignedProperties> _assignedRepository;
        public AssignedService(IAssignedRepository<AssignedProperties> assignedRepository)
        {
            _assignedRepository = assignedRepository;
        }
        public IEnumerable<AssignedProperties> Get()
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

        public void Insert(AssignedProperties assignedProperty)
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
