using ApiLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateCodeController : ControllerBase
    {
        private readonly IStateCodeService<StateTable> _stateCode;
        public StateCodeController(IStateCodeService<StateTable> stateCode)
        {
            _stateCode = stateCode;
        }
        [HttpGet]
        public async Task<IActionResult> GetState()
        {
            try
            {
                var obj = _stateCode.GetAllStates().ToList();
                if (obj != null)
                {
                    return Ok(new ResponseResult<List<StateTable>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = obj
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<StateTable>>
                    {
                        IsSuccess = true,
                        message = "Data Not Found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<StateTable>>
                {
                    IsSuccess = false,
                    message = "Something Went Wrong."
                });
            }
        }
    }
}
