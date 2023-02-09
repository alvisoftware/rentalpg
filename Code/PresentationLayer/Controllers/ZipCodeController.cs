using ApiLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipCodeController : ControllerBase
    {
        private readonly IZipCodeService<ZipCodeTable> _zipCodeService;
        public ZipCodeController(IZipCodeService<ZipCodeTable> zipCode)
        {
            _zipCodeService= zipCode;
        }
        [HttpGet]
        public async Task<IActionResult> GetZipCode()
        {
            try
            {
                var obj = _zipCodeService.GetZipCode().ToList();
                if (obj != null)
                {
                    return Ok(new ResponseResult<List<ZipCodeTable>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = obj
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<ZipCodeTable>>
                    {
                        IsSuccess = true,
                        message = "Data Not Found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<ZipCodeTable>>
                {
                    IsSuccess = false,
                    message = "Something Went Wrong."
                });
            }
        }
    }
}
