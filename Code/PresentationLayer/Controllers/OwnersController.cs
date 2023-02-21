using ApiLayer.Common;
using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Service_Layer.Services;
using Service_Layer.IServices;
using DomainLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService<Owners> _ownerService;
        private readonly IUserRoleService<Users> _userRoleService;
        public OwnersController(IUserRoleService<Users> userRoleService,IOwnerService<Owners> ownerService)
        {
            _userRoleService = userRoleService;
            _ownerService = ownerService;            
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<List<Owners>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOwners()
        {
            try
            {
                var obj =  _ownerService.GetAll().ToList();
                if(obj != null)
                {
                    return Ok(new ResponseResult<List<Owners>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = obj
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<Owners>>
                    {
                        IsSuccess = true,
                        message = "Data Not Found"
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<Owners>>
                {
                    IsSuccess = false,
                    message ="Something Went Wrong."
                });
            }   
        }
        [HttpGet]
        [Route("GetownerRent")]
        public async Task<IActionResult> GetOwnerRent(long ownerid)
        {
            var owner = _ownerService.GetOwnerRent(ownerid).ToList();
            if (owner != null)
            {
                return Ok(new ResponseResult<List<RentSchedules>>
                {
                    IsSuccess = true,
                    message = "",
                    Result = owner
                });
            }
            else
            {
                return NotFound(new ResponseResult<List<RentSchedules>>
                {
                    IsSuccess = true,
                    message = "OwnerRentnotfound"
                });
            }
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateOwner(Owners owners)
        {
            try
            {
                if(owners== null )
                {
                    return BadRequest(new ResponseResult<Owners>
                    {
                        IsSuccess = false,
                        message = "OwnerExist"
                    }) ;
                }
                else
                {
                    Users user = new Users();
                    user.relaventid = Convert.ToInt16(owners.id);
                    user.userName = owners.email;
                    user.password = owners.password;
                    user.role =  Users.userrole.owner;
                    _userRoleService.Add(user);

                    _ownerService.Insert(owners);
                    return Ok(new ResponseResult<Owners>
                    {
                        IsSuccess = true,
                        message ="RecordSave",
                        Result= owners
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<Owners>
                {
                    IsSuccess = false,
                    message = "Record Failed"
                });
            }
        }
    }
}

