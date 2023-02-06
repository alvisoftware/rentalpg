using ApiLayer.Common;
using Domain_Layer.Data;
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
    public class AssignedController : ControllerBase
    {
        private readonly IAssignedService<AssignedProperties> _assignedService;
        private readonly IRentCountService<RentCountModel> _countService;
        private readonly IRentMasterService<RentMaster> _rentMasterService;
       

        public AssignedController(IRentMasterService<RentMaster> rentMasterService,IRentCountService<RentCountModel> countService,IAssignedService<AssignedProperties> assignedService, ApplicationDbContext applicationDbContext)
        {
            _rentMasterService = rentMasterService;
            _countService = countService;
            _assignedService = assignedService;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(ResponseResult<List<AssignedProperties>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAssignedProperty()
        {
            try
            {
                var result = _assignedService.Get().ToList();
                if (result != null)
                {
                    return Ok(new ResponseResult<List<AssignedProperties>>
                    {
                        IsSuccess= true,
                        message="",
                        Result=result
                    });
                }
                else
                {
                    return NotFound(new ResponseResult<List<AssignedProperties>>
                    {
                        IsSuccess = true,
                        message = "Assigne not found"
                    });
                }
            }
            catch(Exception ex) 
            {
                return StatusCode(500, new ResponseResult<List<AssignedProperties>>
                {
                    IsSuccess = false,
                    message = "Somthing went wrong"
                });
            }
        }
        [Route("Insert")]
        [HttpPost]
        public async Task<IActionResult> CreateAsssignedproperty(RentMaster rentMaster)
        {
            try
             {
                if (rentMaster == null)
                {
                    return BadRequest(new ResponseResult<RentMaster>
                    {
                        IsSuccess = true,
                        message="PropertyExist"
                    });
                }
                else
                {
                    AssignedProperties assignedProperties = new AssignedProperties();
                    assignedProperties.propertyid= rentMaster.propertyid;
                    assignedProperties.tenantid = rentMaster.tenantid;
                    _assignedService.Insert(assignedProperties);
                   
                    _rentMasterService.Insert(rentMaster);

                    RentCountModel rentCount = new RentCountModel();
                    rentCount.startdate = Convert.ToDateTime(rentMaster.startdate);
                    rentCount.enddate = Convert.ToDateTime(rentMaster.enddate);
                    rentCount.amount = rentMaster.amount;
                    List<RentCountModel> rentCounts=  _countService.GetRentCounts(rentCount);

                    List<RentDetails> rentDetails = new List<RentDetails>();
                    foreach(var details in rentCounts)
                    {
                        rentDetails.Add(new RentDetails() { amount=details.amount, rentid=rentMaster.id, 
                            enddate=details.enddate, startdate=details.startdate });
                    }
                    _countService.AddRent(rentDetails);

                    return Ok(new ResponseResult<AssignedProperties>
                    {
                        IsSuccess = true,
                        message = "RecordSave",
                        Result = assignedProperties
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<AssignedProperties>
                {
                    IsSuccess = false,
                    message = "somthing went wrong"
                });
            }

        }
    }
}
