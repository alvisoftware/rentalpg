using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        //private DbSet<T> role;
        private readonly IConfiguration iconfiguration;
        public UserRoleRepository(ApplicationDbContext applicationDbContext, IConfiguration iconfiguration)
        {
            _applicationDbContext = applicationDbContext;
            //role = _applicationDbContext.Set<T>();
            this.iconfiguration = iconfiguration;
        }
      
        public Tokens Authenticate(UserRole usersrole)
        {
            if(!_applicationDbContext.users.Any(x=>x.userName==usersrole.userName && x.password== usersrole.password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersrole.userName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

        //public void login(T login)
        //{
        //    if (login == null)
        //    {
        //        throw new ArgumentException("login");
        //    }
        //    role.Add(login);
        //    _applicationDbContext.SaveChanges();
        //}

        //public void SaveChanges()
        //{
        //    _applicationDbContext.SaveChanges();
        //}
    }
}
