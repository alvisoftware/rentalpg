using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface ISubTableRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Insert(T subtable);
        void SaveChanges(Subtable subtable);
    }
}
