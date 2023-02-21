using Domain_Layer.Data;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class MessageDetailsRepository<T> : IMessageDetailsRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entites;
        public MessageDetailsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            //entites = _applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entites.AsEnumerable();
        }

        public void insert(T messagedetails)
        {
            if(messagedetails== null)
            {
                throw new ArgumentException("message");
            }
            entites.Add(messagedetails);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
