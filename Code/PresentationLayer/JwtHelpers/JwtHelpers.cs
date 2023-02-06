using DomainLayer.Models;
using System.Security.Claims;

namespace ApiLayer.JwtHelpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserModel userAccounts,Guid Id)
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userAccounts.userName)
            };
            return claims;
        }
        public static IEnumerable<Claim> GetClaims(this UserModel userAccounts)
        {
            return GetClaims(userAccounts);
        }
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
