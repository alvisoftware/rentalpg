using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface ICountryRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}
