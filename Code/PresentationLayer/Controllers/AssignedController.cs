using ApiLayer.Common;
using Domain_Layer.Data;
using DomainLayer.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Modes.Gcm;
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
                    #region add propertyrent
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
                    
                    #endregion

                    #region PdfGenerate
                    Document document = new Document(PageSize.A4, 36, 36, 36, 36);
                    string filepath = "C:\\PDF\\rentcount.pdf";
                    using (FileStream fileStream = new FileStream(filepath, FileMode.Append, FileAccess.Write, FileShare.None))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                        document.Open();
                        PdfPTable table = new PdfPTable(3);
                        //table.DefaultCell.PaddingLeft = 1000;
                        table.AddCell("Amount");
                        table.AddCell("StartDate");
                        table.AddCell("EndDate");

                        foreach(var details in rentDetails)
                        {
                            table.AddCell(details.amount + ".00");
                            table.AddCell(Convert.ToString(details.startdate.ToShortDateString()));
                            table.AddCell(Convert.ToString(details.enddate.ToShortDateString()));
                            //table.PaddingTop= 1000f;
                        }
                        document.Add(table);
                        document.Close();
                    }
                    #endregion
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
