using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IRentTableRepository<T> where T : class
    {
        void Add(T entity);
        void SaveChanges();
    }
}
