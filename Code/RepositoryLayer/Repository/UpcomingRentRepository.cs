using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class UpcomingRentRepository<T> : IUpcomingRentRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> values;
        public UpcomingRentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            values = _applicationDbContext.Set<T>();
        }

        public List<T> GetUpcomingRentList()
        {
            return values.ToList();
        }
    }
}
