using ApiLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService<CityModel> _cityService;
        public CityController(ICityService<CityModel> cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCity()
        {
            try
            {
                var obj = _cityService.GetAll().ToList();
                if (obj != null)
                {
                    return Ok(new ResponseResult<List<CityModel>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = obj
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<CityModel>>
                    {
                        IsSuccess = true,
                        message = "Data Not Found"
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<CityModel>>
                {
                    IsSuccess = false,
                    message = "Something Went Wrong."
                });
            }

        }
    }
}
