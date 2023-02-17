using Domain_Layer.Models;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryLayer.CustomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IOwnerRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        List<OwnerBackendModel> GetOwnerRemainProperty();
        IEnumerable<RentSchedules> GetOwnerRent(long ownerid);
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
