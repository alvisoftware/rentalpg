using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RepositoryLayer.Repository
{
    public class MessageDetailsRepository<T> : IMessageDetailsRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> values;
        public MessageDetailsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            values =  _applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return values.AsEnumerable();
        }

        public void insert(T messagedetails)
        {
            if (messagedetails == null)
            {
                throw new ArgumentException("message");
            }
            values.Add(messagedetails);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
