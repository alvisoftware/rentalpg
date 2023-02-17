using Domain_Layer.Data;
using Domain_Layer.Models;
//using DomainLayer.Migrations;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryLayer.CustomeModel;
using RepositoryLayer.IRepository;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class DashbordRepository<T> : IDashbordRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ITenantRepository<Tenant> tenantRepository;
        private readonly IOwnerRepository<Owners> ownerRepository;
        public DashbordRepository(ApplicationDbContext applicationDbContext, ITenantRepository<Tenant> tenantRepository,IOwnerRepository<Owners> ownerRepository)
        {
            _applicationDbContext = applicationDbContext;
            this.tenantRepository = tenantRepository;
            this.ownerRepository = ownerRepository;
        }

        public DashbordModel DashbordModel(long ownerid, string role)
        {
            long availableProperty = _applicationDbContext.propertyInfos.Where(x => x.ownerid == ownerid).Count();
            List<RentSchedules> schedule=new();
            if (role == Users.userrole.tenant.ToString())
            {
                schedule = this.tenantRepository.GetTenantRent(ownerid).ToList();
            }
            else if(role == Users.userrole.owner.ToString())
            {
                schedule = this.ownerRepository.GetOwnerRent(ownerid).ToList();
            }
            int rentedProperty = 1;
            return new DashbordModel()
            {
                avilable = Convert.ToInt32(availableProperty),
                rent = rentedProperty,
                upcomingrent = schedule
            };
        }
    }
}
