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
    public class UserRoleRepository<T> : IUserRoleRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> role;
        private readonly IConfiguration iconfiguration;
        public UserRoleRepository(ApplicationDbContext applicationDbContext, IConfiguration iconfiguration)
        {
            _applicationDbContext = applicationDbContext;
            role = _applicationDbContext.Set<T>();
            this.iconfiguration = iconfiguration;
        }

        public void Add(T user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            role.Add(user);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public UserModel Authenticate(Users users)
        {
            Users checkExistinguser = _applicationDbContext.users.Where(x => x.userName == users.userName && x.password == users.password).FirstOrDefault();

            if (checkExistinguser == null)
            {
                return null;
            }
            UserModel existingUsermodel = new UserModel();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.userName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            existingUsermodel.userName = checkExistinguser.userName;
            existingUsermodel.name = checkExistinguser.userName;
            existingUsermodel.token = tokenHandler.WriteToken(token);
            existingUsermodel.role = checkExistinguser.role.ToString();
            existingUsermodel.relaventid = checkExistinguser.relaventid.ToString();
            return existingUsermodel;
        }
    }
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