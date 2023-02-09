using ApiLayer.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.CustomeModel;
using Service_Layer.IServices;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashbordController : ControllerBase
    {
        private readonly IDashbordService<DashbordModel> _dashbordService;
        public DashbordController(IDashbordService<DashbordModel> dashbordService)
        {
            _dashbordService = dashbordService;
        }
        [HttpGet]
        public async Task<IActionResult> Propertycount()
        {
            var result = _dashbordService.DashbordModel();
             return Ok(result);
        }
    }
}
