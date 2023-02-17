using ApiLayer.Common;
//using DomainLayer.Migrations;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryLayer.CustomeModel;
using Service_Layer.IServices;
using Service_Layer.Services;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashbordController : ControllerBase
    {
        private readonly IDashbordService<DashbordModel> _dashbordService;
        private readonly IPropertyService<PropertyInfo> _propertyService;
        private readonly IRentMasterService<RentMaster> _rentMasterService;
        public DashbordController(IDashbordService<DashbordModel> dashbordService,IPropertyService<PropertyInfo> propertyService,IRentMasterService<RentMaster> rentMasterService)
        {
            _dashbordService = dashbordService;
            _propertyService = propertyService;
            _rentMasterService = rentMasterService;
        }
        [HttpGet]
        public async Task<IActionResult> Propertycount(long oId,string role)
        {
            try
            {
                return Ok(new ResponseResult<DashbordModel>
                {
                    IsSuccess = true,
                    message = "",
                    Result = _dashbordService.DashbordModel(oId,role)
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseResult<List<DashbordModel>>
                {
                    IsSuccess = false,
                    message = "somthing went wrong"
                });
            }
        }
    }
}


