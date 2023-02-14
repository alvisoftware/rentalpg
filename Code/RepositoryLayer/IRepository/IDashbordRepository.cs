//using DomainLayer.Migrations;
using DomainLayer.Models;
using RepositoryLayer.CustomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IDashbordRepository<T> where T : class
    {
        DashbordModel DashbordModel();
        
    }
}
