using ApiLayer.Common;
using Domain_Layer.Data;
using Domain_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Service_Layer.Services;
using Service_Layer.IServices;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService<Owners> _ownerService;
        private readonly ApplicationDbContext _applicationDbContext;
        public OwnersController(IOwnerService<Owners> ownerService, ApplicationDbContext applicationDbContext
            )
        {
            _ownerService = ownerService;
            _applicationDbContext = applicationDbContext;
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
        [HttpPost]
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
            //if (owners != null)
            //{
            //    _ownerService.Insert(owners);
            //    return Ok("OwnerCreated");
            //}
            //else
            //{
            //    return BadRequest("Somthing Went Wrong");
            //}
        }
    }
}




//var obj = _ownerService.GetAll();
//if (obj == null)
//{
//    return NotFound();
//}
//else
//{
//    return Ok(obj);
//}