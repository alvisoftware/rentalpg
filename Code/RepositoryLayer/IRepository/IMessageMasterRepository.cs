using DomainLayer.Models;
using RepositoryLayer.CustomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IMessageMasterRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void insert(T messagemaster);
        void SaveChanges();
    }
}
