using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.IServices
{
    public interface IPropertyService<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Insert(T owners);
        List<PropertyModel> GetPropertyWithOwnerName();
    }
}
