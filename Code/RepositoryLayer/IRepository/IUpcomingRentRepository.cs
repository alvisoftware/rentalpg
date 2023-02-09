using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IUpcomingRentRepository<T> where T : class
    {
        List<T> GetUpcomingRentList();
    }
}
