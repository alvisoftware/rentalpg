using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IAssignedRepository<T> where T : class
    {
        IEnumerable<T> Get();
        void Add(T entity);
        void SaveChanges();
    }
}
