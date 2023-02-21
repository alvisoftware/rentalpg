using Domain_Layer.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class MessageMasterRepository<T> : IMessageMasterRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entites;
        public MessageMasterRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entites = _applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entites.AsEnumerable();
        }

        public void insert(T messagemaster)
        {
            if(messagemaster == null)
            {
                throw new ArgumentNullException("message");
            }
            entites.Add(messagemaster);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
