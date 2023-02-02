using ApiLayer.Common;
using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedController : ControllerBase
    {
        private readonly IAssignedService<Assigned> _assignedService;
        private readonly ApplicationDbContext _applicationDbContext;
        public AssignedController(IAssignedService<Assigned> assignedService, ApplicationDbContext applicationDbContext)
        {
            _assignedService = assignedService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(ResponseResult<List<Assigned>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAssignedProperty()
        {
            try
            {
                var result = _assignedService.Get().ToList();
                if (result != null)
                {
                    return Ok(new ResponseResult<List<Assigned>>
                    {
                        IsSuccess= true,
                        message="",
                        Result=result
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<Assigned>>
                    {
                        IsSuccess = true,
                        message = "Assigne not found"
                    });
                }
            }
            catch(Exception ex) 
            {
                return StatusCode(500, new ResponseResult<List<Assigned>>
                {
                    IsSuccess = false,
                    message = "Somthing went wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsssignedproperty(Assigned assignedProperty)
        {
            try
            {
                if (assignedProperty == null)
                {
                    return BadRequest(new ResponseResult<Assigned>
                    {
                        IsSuccess = true,
                        message="PropertyExist"
                    });
                }
                else
                {
                    _assignedService.Insert(assignedProperty);
                    return Ok(new ResponseResult<Assigned>
                    {
                        IsSuccess = true,
                        message = "RecordSave",
                        Result = assignedProperty
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<Assigned>
                {
                    IsSuccess = false,
                    message = "somthing went wrong"
                });
            }

        }
    }
}
