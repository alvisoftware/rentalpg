using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.IServices
{
    public interface IOwnerService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T owners);
        void Update(T owners);
        void Delete(T owners);
        void Remove(T owners);
    }
}
