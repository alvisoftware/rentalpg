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
    public class RentTableRepository<T>:IRentTableRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> values;
        public RentTableRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            values = _applicationDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            values.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
