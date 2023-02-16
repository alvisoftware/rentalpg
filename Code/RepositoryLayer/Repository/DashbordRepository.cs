using Domain_Layer.Data;
//using DomainLayer.Migrations;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class DashbordRepository<T> : IDashbordRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DashbordRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public DashbordModel DashbordModel(long ownerid)
        {
            long availableProperty = _applicationDbContext.propertyInfos.Where(x => x.ownerid == ownerid).Count();
            int rentedProperty = 1;
            List<TenantRentModel> upcomingRent = new List<TenantRentModel>();
            upcomingRent.Add(new TenantRentModel() 
            { 
                propertyname="abc",rentamount="1000",startdate=Convert.ToDateTime("01/02/2023"),enddate=Convert.ToDateTime("10/02/2023"),status="available"
            });
            return new DashbordModel()
            {
                avilable = Convert.ToInt32(availableProperty),
                rent = rentedProperty,
                upcomingrent = upcomingRent
            };
        }
    }
}
