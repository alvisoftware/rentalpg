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
    public class SubTableController : ControllerBase
    {
        private readonly ISubTableService<Subtable> _subTableService;
        private readonly ApplicationDbContext _applicationDbContext;
        public SubTableController(ISubTableService<Subtable> subTableService, ApplicationDbContext applicationDbContext)
        {
            _subTableService = subTableService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetSubtable()
        {
            var result = _subTableService.GetAll().ToList();
            try 
            { 
                if (result != null)
                {
                    return Ok(new ResponseResult<List<Subtable>>
                    {
                        IsSuccess= true,
                        message="",
                        Result= result
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<Subtable>>
                    {
                        IsSuccess = true,
                        message = "Subtable not found"
                    });
                }
            }
            catch(Exception ex) 
            {
                return StatusCode(500, new ResponseResult<List<Subtable>>
                {
                    IsSuccess= false,
                    message="Somthing Went Wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubTable(Subtable subtable)
        {
            try
            {
                if(subtable == null)
                {
                    return BadRequest(new ResponseResult<Subtable>
                    {
                        IsSuccess = true,
                        message = "Subtable not exist"
                    });
                }
                else
                {
                    _subTableService.insert(subtable);
                    return Ok(new ResponseResult<Subtable>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = subtable
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<Subtable>
                {
                    IsSuccess = false,
                    message = "somthing went wrong"
                });
            }
        }
    }
}
