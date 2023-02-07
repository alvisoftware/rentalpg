using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IUserRoleRepository<T> where T : class
    {
        //void login(T login);
        void SaveChanges();
        //List<UsersModel> usersModels { get; set; }
        void Add(T user);
        Tokens Authenticate(Users usersrole);
    }
}
