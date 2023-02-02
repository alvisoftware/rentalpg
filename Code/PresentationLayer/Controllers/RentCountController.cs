using ApiLayer.Common;
using Domain_Layer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.CustomeModel;
using Service_Layer.IServices;
using Service_Layer.Services;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentCountService<RentCountModel> _countService;
        private readonly ApplicationDbContext _applicationDbContext; 
        public RentController(IRentCountService<RentCountModel> rentCountService, ApplicationDbContext applicationDbContext)
        {
            _countService = rentCountService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        [Route("Rentcalcuation")]
        public async Task<IActionResult> Rentcalcuation(RentCountModel rentCountModel)
        {
            try
            {
                if (rentCountModel == null)
                {
                    return BadRequest(new ResponseResult<RentCountModel>
                    {
                        IsSuccess = false,
                        message = "Proeprty not Exist"
                    });
                }
                else
                {
                    
                    return Ok(new ResponseResult<List<RentCountModel>>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = _countService.GetRentCounts(rentCountModel)
                });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<RentCountModel>
                {
                    IsSuccess = false,
                    message = "Record Saved faile"
                });
            }
        }

    }
}
