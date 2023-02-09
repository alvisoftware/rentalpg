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
    public class StateCodeService : IStateCodeService<StateTable>
    {
        private readonly IStateRepository<StateTable> _stateRepository;
        public StateCodeService(IStateRepository<StateTable> stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public IEnumerable<StateTable> GetAllStates()
        {
             return _stateRepository.GetAll();
        }
    }
}
