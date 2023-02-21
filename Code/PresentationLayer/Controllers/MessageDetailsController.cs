using ApiLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageDetailsController : ControllerBase
    {
        private readonly IMessageDetailsService<MesssageDetails> _messageDetails;
        public MessageDetailsController(IMessageDetailsService<MesssageDetails> messageDetails)
        {
            _messageDetails = messageDetails;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<List<MesssageDetails>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMessageMaster()
        {
            try
            {
                var messagesdetails = _messageDetails.GetAll().ToList();
                if (messagesdetails != null)
                {
                    return Ok(new ResponseResult<List<MesssageDetails>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = messagesdetails
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<MesssageDetails>>
                    {
                        IsSuccess = true,
                        message = "messagedetails Not Found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<MesssageDetails>>
                {
                    IsSuccess = false,
                    message = "somting went Wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageMaster(MesssageDetails messsageDetails)
        {
            try
            {
                if (messsageDetails == null)
                {
                    return BadRequest(new ResponseResult<MesssageDetails>
                    {
                        IsSuccess = false,
                        message = "messagedetails not Exist"
                    });
                }
                else
                {
                    _messageDetails.Insert(messsageDetails);
                    return Ok(new ResponseResult<MesssageDetails>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = messsageDetails
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<MesssageDetails>
                {
                    IsSuccess = false,
                    message = "Record Saved faile"
                });
            }
        }
    }
}
