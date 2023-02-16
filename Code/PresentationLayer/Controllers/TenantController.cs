using ApiLayer.Common;
using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service_Layer.IServices;
using System.ComponentModel.DataAnnotations;
using System.Security;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService<Tenant> _tenantService;
        private readonly ApplicationDbContext _applicationDbContext;
        public readonly IUserRoleService<Users> _userRoleService;
        public TenantController(IUserRoleService<Users> userRoleService,ITenantService<Tenant> tenantService, ApplicationDbContext applicationDbContext)
        {
            _tenantService = tenantService;
            _userRoleService = userRoleService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        [Route("tenantrent")]
        public async Task<IActionResult> TenantRent()
        {
            var tenant = _tenantService.TenantRent().ToList();
            if (tenant != null)
            {
                return Ok(new ResponseResult<List<Tenant>>
                {
                    IsSuccess = true,
                    message = "",
                    Result = tenant
                });
            }
            else
            {
                return NotFound(new ResponseResult<List<Tenant>>
                {
                    IsSuccess = true,
                    message = "Tentnat Rent not found"
                });
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<List<Tenant>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTenant()
        {
            try
            {
                var tenant = _tenantService.GetAll().ToList();
                if (tenant != null)
                {
                    return Ok(new ResponseResult<List<Tenant>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = tenant
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<Tenant>>
                    {
                        IsSuccess = true,
                        message = "Tenant not found"
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<Tenant>>
                {
                    IsSuccess = false,
                    message = "somthing went wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateTenant(Tenant tenant)
        {
            try
            {
                if(tenant == null)
                {
                    return BadRequest(new ResponseResult<Tenant>
                    {
                        IsSuccess = false,
                        message = "Tenant Not Exist"
                    });
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        Users user = new Users();
                        user.id = tenant.id;
                        user.userName = tenant.firsttname + ' ' + tenant.lasttname;
                        user.password = tenant.lasttname;
                        user.role = Users.userrole.tenant;
                        _userRoleService.Add(user);
                    }
                    _tenantService.insert(tenant);
                    return Ok(new ResponseResult<Tenant>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = tenant
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<Tenant>
                {
                    IsSuccess = false,
                    message = "Record Saved Faild"
                });
            }
        }
    }
}
