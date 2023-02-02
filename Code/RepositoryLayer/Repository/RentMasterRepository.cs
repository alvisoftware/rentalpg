using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.CustomeModel;
using RepositoryLayer.IRepository;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class RentMasterRepository<T> : IRentMasterRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DbSet<T> values;
        public RentMasterRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
            values=_applicationDbContext.Set<T>();
        }

        public void Add(T rentmaster)
        {
            if(rentmaster == null)
            {
                throw new ArgumentException("rentmaster");
            }
            values.Add(rentmaster);
            _applicationDbContext.SaveChanges();
        }

        public List<RentModel> GetPropertyWithOwnerName()
        {
            var query = _applicationDbContext.rentMasters.Join(_applicationDbContext.owners, own => own.ownerid, rent => rent.id,
                 (rent, own) => new RentModel
                 {
                     ownername= own.firstname + "" + own.lastname,
                     startdate = rent.startdate,
                     enddate = rent.enddate,
                     payamount=rent.amount
                 }).ToList();

            return query;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
