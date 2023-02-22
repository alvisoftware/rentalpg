﻿using Domain_Layer.Data;
using Domain_Layer.Models;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class Owners<T> : IOwnerRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;
        public Owners(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        
        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.id == Id);
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            //_applicationDbContext.SaveChanges();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }
        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            //_applicationDbContext.SaveChanges();
        }

        List<OwnerBackendModel> IOwnerRepository<T>.GetOwnerRemainProperty()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RentSchedules> GetOwnerRent(long ownerid = 0)
        {
            var ownerRent = (from rm in _applicationDbContext.rentMasters
                              join rd in _applicationDbContext.rentTables on rm.id equals rd.rentid
                              join pi in _applicationDbContext.propertyInfos on rm.propertyid equals pi.id
                              join te in _applicationDbContext.tenants on rm.tenantid equals te.id
                              where rm.ownerid == ownerid && rd.ispaid==false   
                            select new RentSchedules
                            {
                                  propertytitle = pi.name,
                                  rentamount = rd.amount,
                                  tenantname = te.firsttname + ' ' + te.lasttname,
                                  status = rd.ispaid ? "Paid" : "Unpaid",
                                  startDate = rd.startdate,
                                  endDate = rd.enddate
                            }
                            ).Take(5).OrderBy(x=>x.startDate);
            return ownerRent.AsEnumerable();
        }
    }
}
