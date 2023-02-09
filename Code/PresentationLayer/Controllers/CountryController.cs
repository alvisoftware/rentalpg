using ApiLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;
using Service_Layer.Services;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService<CountryTable> _countryService;
        public CountryController(ICountryService<CountryTable> countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public async Task<IActionResult> Getcountry()
        {
            try
            {
                var obj = _countryService.GetAll().ToList();
                if (obj != null)
                {
                    return Ok(new ResponseResult<List<CountryTable>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = obj
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<CountryTable>>
                    {
                        IsSuccess = true,
                        message = "Data Not Found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<CountryTable>>
                {
                    IsSuccess = false,
                    message = "Something Went Wrong."
                });
            }
        }
    }
}
