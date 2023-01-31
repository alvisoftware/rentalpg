using DomainLayer.Models;
using RepositoryLayer.IRepository;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class QueriesService : IQueriesServices<Queries>
    {
        private readonly IQueriesRepository<Queries> _queriesRepository;
        public QueriesService(IQueriesRepository<Queries> queriesRepository)
        {
            _queriesRepository = queriesRepository;
        }
        public IEnumerable<Queries> GetAll()
        {
            try
            {
                return _queriesRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
                return null;
            }
        }

        public void Insert(Queries queries)
        {
            try
            {
                if (queries != null)
                {
                    _queriesRepository.Insert(queries);
                    //_propertyInfo.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
