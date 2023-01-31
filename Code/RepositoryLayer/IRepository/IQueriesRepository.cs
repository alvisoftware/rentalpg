using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IQueriesRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Insert(T queries);
        void SaveChanges();
    }
}
