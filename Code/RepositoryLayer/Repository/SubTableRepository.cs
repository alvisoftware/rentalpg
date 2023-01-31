using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class SubTableRepository<T> : ISubTableRepository<T> where T : class
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public DbSet<T> values;
        public SubTableRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            values = _applicationDbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return values.AsEnumerable();
        }

        public void Insert(T subtable)
        {
            if (subtable == null)
            {
                throw new ArgumentException("values");
            }
            values.Add(subtable);
            _applicationDbContext.SaveChanges();
        }
        public void SaveChanges(Subtable subtable)
        {
            _applicationDbContext.SaveChanges(subtable.messageid.ToString());
        }
    }
}
