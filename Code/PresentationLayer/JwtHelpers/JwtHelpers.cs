using DomainLayer.Models;
using System.Security.Claims;

namespace ApiLayer.JwtHelpers
{
    public static class JwtHelpers
    {
        public static UserRole GetTokenKey(UserRole model)
        {
            try 
            { 
                var UserTokens = new UserRole();
                UserTokens.userName = model.userName;
                UserTokens.password = model.password;
                return UserTokens;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
