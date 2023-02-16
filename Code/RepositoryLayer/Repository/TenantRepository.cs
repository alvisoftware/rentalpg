using Domain_Layer.Data;
using Domain_Layer.Models;
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
    public class TenantRepository<T>:ITenantRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entites;
        public TenantRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
            entites= _applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            var query = (from PropertyInfo in _applicationDbContext.propertyInfos
                         join Owners in _applicationDbContext.owners on PropertyInfo.ownerid equals Owners.id
                         select new
                         {
                             title = PropertyInfo.name,
                             owner = Owners.firstname + " " + Owners.lastname,
                             date = PropertyInfo.availabledate,
                             pid = PropertyInfo.id,
                             oid = Owners.id
                         }).ToList();
            return entites.AsEnumerable();
        }

        public IEnumerable<T> GetTenantRent()
        {

            return entites.AsEnumerable();
        }

        public void insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entites.Add(entity);
            _applicationDbContext.SaveChanges();
        }
        public void SaveChnages()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
