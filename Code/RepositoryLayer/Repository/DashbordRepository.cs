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
        private DbSet<T> entites;
        public DashbordModel DashbordModel(long ownerid)
        {
            int availableProperty = _applicationDbContext.propertyInfos.Where(x => x.ownerid == ownerid).Count() ;
            return new DashbordModel() {  avilable=availableProperty};
        }
    }
}

//var check = _applicationDbContext.users.Where(x => x.role == Users.userrole.admin);
//if (check != null)
//{
//    return null;
//}

//List<PropertyInfo> result = _applicationDbContext.propertyInfos.GroupBy(t => t.propertytypeid)
//                .Select(t => new PropertyInfo
//                {
//                    propertytypeid = t.Key,
//                    count = t.Key + "Totoal Property" + t.Count().
//                });

//var result = _applicationDbContext.propertyInfos.Join(
//_applicationDbContext.propertyInfos,
//(property) => new DashbordModel
//{
//        property = property.propertytypeid.ToString()
//});

//return result;

//var result = _applicationDbContext.propertyInfos.Include("PropertyInfos")
//        .ToList()
//        .GroupBy(e => e.propertytypeid).Select(y => new
//        {
//            totalproperty = y.First().propertytypeid,
//            count = y.Count()
//        }).ToList();

//var result = _applicationDbContext.propertyInfos.GroupBy(n => n.propertytypeid)
//            .Select(g => new { CategoryName = g.Key, Count = g.Count() }).ToList();
//List<PropertyInfo> propList = new List<PropertyInfo>();
//for (int i = 0; i < result.ToList().Count; i++)
//{
//    propList.Add(new PropertyInfo { id = result[i].CategoryName, count = result[i].Count });
//}
//return result;