using DomainLayer.Models;
using RepositoryLayer.IRepository;
using RepositoryLayer.Model;
using RepositoryLayer.Repository;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class PropertyService : IPropertyService<PropertyInfo>
    {
        private readonly IPropertyInfo<PropertyInfo> _propertyInfo;
        public PropertyService(IPropertyInfo<PropertyInfo> propertyInfo)
        {
            _propertyInfo = propertyInfo;
        }

        public IEnumerable<PropertyInfo> GetAll()
        {
            try
            {
                return _propertyInfo.GetAll();
            }
            catch (Exception)
            {
                throw;
                return null;
            }
        }
        public List<PropertyModel> GetPropertyWithOwnerName()
        {
            try
            {
                return _propertyInfo.GetPropertyWithOwnerName();
            }
            catch
            {
                throw;
                return null;
            }
        }
        public void Insert(PropertyInfo property)
        {
            try
            {
                if(property != null)
                {
                    _propertyInfo.insert(property);
                    //_propertyInfo.SaveChanges();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
