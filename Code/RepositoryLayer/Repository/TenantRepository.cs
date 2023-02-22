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
    public class TenantRepository<T> : ITenantRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entites;
        public TenantRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entites = _applicationDbContext.Set<T>();
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

        public IEnumerable<RentSchedules> GetTenantRent(long tenantId = 0)
        {
            var tenantRent = (from rm in _applicationDbContext.rentMasters
                              join rd in _applicationDbContext.rentTables on rm.id equals rd.rentid
                              join pi in _applicationDbContext.propertyInfos on rm.propertyid equals pi.id
                              join te in _applicationDbContext.tenants on rm.tenantid equals te.id
                              where rm.tenantid == tenantId && rd.ispaid==false
                              select new RentSchedules
                              {
                                  propertytitle = pi.name,
                                  rentamount = rd.amount,
                                  tenantname = te.firsttname+' '+te.lasttname,
                                  status = rd.ispaid ? "Paid" : "Unpaid",
                                  startDate = rd.startdate,
                                  endDate = rd.enddate
                              }
                            ).Take(5).OrderBy(x=>x.endDate);
            return tenantRent.AsEnumerable();
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
