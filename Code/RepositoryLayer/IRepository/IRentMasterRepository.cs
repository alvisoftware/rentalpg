using RepositoryLayer.CustomeModel;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IRentMasterRepository<T> where T : class
    {
        void Add(T rentmaster);
        void SaveChanges();
        List<RentModel> GetPropertyWithOwnerName();
    }

}
