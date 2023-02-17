using Domain_Layer.Models;
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class OwnerService : IOwnerService<Owners>
    {
        private readonly IOwnerRepository<Owners> _OwnRepository;
        public OwnerService(IOwnerRepository<Owners> ownRepository)
        {
            _OwnRepository = ownRepository;
        }
        public void Delete(Owners owners)
        {
            try
            {
                if (owners != null)
                {
                    _OwnRepository.Delete(owners);
                    //_OwnRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Owners Get(int Id)
        {
            try
            {
                var obj = _OwnRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Owners> GetAll()
        {
            try
            {
                return _OwnRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
                return null;
            }
        }

        public IEnumerable<RentSchedules> GetOwnerRent(long ownerid)
        {
            return _OwnRepository.GetOwnerRent(ownerid);
        }

        public void Insert(Owners owners)
        {
            try
            {
                if (owners != null)
                {
                    _OwnRepository.Insert(owners);
                    _OwnRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(Owners owners)
        {
            try
            {
                if (owners != null)
                 {
                    _OwnRepository.Remove(owners);
                    //_OwnRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(Owners owners)
        {
            try
            {
                if (owners != null)
                {
                    _OwnRepository.Update(owners);
                    //_OwnRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
