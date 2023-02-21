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
    public class MessageMasterController : ControllerBase
    {
        private readonly IMessageMasterService<MessageMaster> _messageMaster;
        public MessageMasterController(IMessageMasterService<MessageMaster> messageMaster)
        {
            _messageMaster= messageMaster;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<List<PropertyInfo>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMessageMaster()
        {
            try
            {
                var messages = _messageMaster.GetAll().ToList();
                if (messages != null)
                {
                    return Ok(new ResponseResult<List<MessageMaster>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = messages
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<MessageMaster>>
                    {
                        IsSuccess = true,
                        message = "message Not Found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<MessageMaster>>
                {
                    IsSuccess = false,
                    message = "somting went Wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageMaster(MessageMaster messageMaster)
        {
            try
            {
                if (messageMaster == null)
                {
                    return BadRequest(new ResponseResult<MessageMaster>
                    {
                        IsSuccess = false,
                        message = "message not Exist"
                    });
                }
                else
                {
                    _messageMaster.Insert(messageMaster);
                    return Ok(new ResponseResult<MessageMaster>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = messageMaster
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<MessageMaster>
                {
                    IsSuccess = false,
                    message = "Record Saved faile"
                });
            }
        }
    }
}
