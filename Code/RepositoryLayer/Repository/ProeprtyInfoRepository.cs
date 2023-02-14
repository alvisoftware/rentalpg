using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepository;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class ProeprtyInfoRepository<T> : IPropertyInfo<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entites;
        public ProeprtyInfoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entites = _applicationDbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
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
        public List<PropertyModel> GetPropertyWithOwnerName()
        {
            var query = _applicationDbContext.propertyInfos.Join(_applicationDbContext.owners, property => property.ownerid, own => own.id,
                 (property, own) => new PropertyModel
                 {
                     title = property.name,
                     owner = own.firstname + "" + own.lastname,
                     date = property.availabledate,
                     pid = property.id,
                     oid = own.id
                 }).ToList();

            return query;
            //return null;
        }
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
//title = PropertyInfo.name
//owner = Owners.firstname + " " + Owners.lastname,
//date = PropertyInfo.availabledate,
//pid = PropertyInfo.id,
//oid = Owners.id