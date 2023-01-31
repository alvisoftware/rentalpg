using Domain_Layer.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class QueriesRepository<T> : IQueriesRepository<T> where T : class
    {
        public readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entites;
        public QueriesRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entites = _applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entites.AsEnumerable();
        }

        public void Insert(T queries)
        {
            if (queries == null)
            {
                throw new ArgumentNullException("entity");
            }
            entites.Add(queries);
            _applicationDbContext.SaveChanges();
        }
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
