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
    public class StateCodeRepository<T> : IStateRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> values;
        public StateCodeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            values = _applicationDbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return values.AsEnumerable();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
