using ApiLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.CustomeModel;
using Service_Layer.IServices;
using Service_Layer.Services;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageMasterController : ControllerBase
    {
        private readonly IMessageMasterService<MesssageMaster> _messageMaster;
        private readonly IMessageDetailsService<MessageDetails> _messageDetails;
        public MessageMasterController(IMessageMasterService<MesssageMaster> messageMaster, IMessageDetailsService<MessageDetails> messageDetails)
        {
            _messageMaster = messageMaster;
            _messageDetails = messageDetails;
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
                    return Ok(new ResponseResult<List<MesssageMaster>>
                    {
                        IsSuccess = true,
                        message = "",
                        Result = messages
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<MesssageMaster>>
                    {
                        IsSuccess = true,
                        message = "message Not Found"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<MesssageMaster>>
                {
                    IsSuccess = false,
                    message = "somting went Wrong"
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageMaster(CommonMessage commonMessage)
        {
            try
            {
                if (commonMessage == null)
                {
                    return BadRequest(new ResponseResult<CommonMessage>
                    {
                        IsSuccess = false,
                        message = "message not Exist"
                    });
                }
                else
                {
                    MesssageMaster messageMaster = new MesssageMaster();
                    messageMaster.propertyid = commonMessage.propertyid;
                    messageMaster.tenantid = commonMessage.tenantid;
                    _messageMaster.Insert(messageMaster);

                    MessageDetails messsageDetails = new MessageDetails();
                    messsageDetails.messagemasterid = messageMaster.id;
                    messsageDetails.replyby = commonMessage.role;
                    messsageDetails.message = commonMessage.message;

                    _messageDetails.Insert(messsageDetails);

                    return Ok(new ResponseResult<CommonMessage>
                    {
                        IsSuccess = true,
                        message = "Record Save",
                        Result = commonMessage
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult<CommonMessage>
                {
                    IsSuccess = false,
                    message = "Record Saved faile"
                });
            }
        }
    }
}
