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
    public class RentMasterController : ControllerBase
    {
        private readonly IRentMasterService<RentMaster> _rentMaster;
        private readonly ApplicationDbContext _applicationDb;
        public RentMasterController(IRentMasterService<RentMaster> rentMaster, ApplicationDbContext applicationDb)
        {
            _rentMaster = rentMaster;
            _applicationDb = applicationDb;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMaster(RentMaster rentMaster)
        {
            try
            {
                if (rentMaster == null)
                {
                    return BadRequest(new ResponseResult<RentMaster>
                    {
                        IsSuccess= false,
                        message="Rent not exists"
                    });
                }
                else
                {
                    _rentMaster.Insert(rentMaster);
                    return Ok(new ResponseResult<RentMaster>
                    {
                        IsSuccess= true,
                        message="",
                        Result = rentMaster
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<RentMaster>
                {
                    IsSuccess = false,
                    message = "somthing wrong"
                });
            }
        }
    }
}
