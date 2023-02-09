//using DomainLayer.Migrations;
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
    public class UserRoleService : IUserRoleService<Users>
    {
        private readonly IUserRoleRepository<Users> _userRepository;
        public UserRoleService(IUserRoleRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(Users entity)
        {
            try
            {
                if(entity != null) 
                {
                    _userRepository.Add(entity);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void login(Users login)
        {
            throw new NotImplementedException();
        }
    }

}