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
        private readonly IMessageDetailsService<MessageDetails> _messageDetails;
        public MessageDetailsController(IMessageDetailsService<MessageDetails> messageDetails)
        {
            _messageDetails = messageDetails;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseResult<List<MessageDetails>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMessageMaster()
        {
            try
            {
                var messagesdetails = _messageDetails.GetAll().ToList();
                if (messagesdetails != null)
                {
                    return Ok(new ResponseResult<List<MessageDetails>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = messagesdetails
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<MessageDetails>>
                    {
                        IsSuccess = true,
                        message = "messagedetails Not Found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<MessageDetails>>
                {
                    IsSuccess = false,
                    message = "somting went Wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageMaster(MessageDetails messsageDetails)
        {
            try
            {
                if (messsageDetails == null)
                {
                    return BadRequest(new ResponseResult<MessageDetails>
                    {
                        IsSuccess = false,
                        message = "messagedetails not Exist"
                    });
                }
                else
                {
                    _messageDetails.Insert(messsageDetails);
                    return Ok(new ResponseResult<MessageDetails>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = messsageDetails
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<MessageDetails>
                {
                    IsSuccess = false,
                    message = "Record Saved faile"
                });
            }
        }
    }
}
