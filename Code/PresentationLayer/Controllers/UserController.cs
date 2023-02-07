using ApiLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.IRepository;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRoleRepository<Users> _roleRepository;
        public UserController(IUserRoleRepository<Users> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(Users userRole)
        {
            try
            {
                var token = _roleRepository.Authenticate(userRole);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(new ResponseResult<string>
                {
                    IsSuccess = true,
                    Result = token.Token
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<Users>
                {
                    IsSuccess = false,
                    message = "Record Saved Failed"
                });
            }
        }
    }
}
