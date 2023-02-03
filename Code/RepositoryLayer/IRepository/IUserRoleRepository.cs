using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IUserRoleRepository
    {
        //void login(T login);
        //void SaveChanges();
        //List<UsersModel> usersModels { get; set; }
        Tokens Authenticate(UserRole usersrole);
    }
}
