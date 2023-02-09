using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service_Layer.IServices;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcomingRentController : ControllerBase
    {
        private readonly IUpcomingRentService<UpcomingRent> _Upcomingservice;
        public UpcomingRentController(IUpcomingRentService<UpcomingRent> upcomingRentService)
        {
            _Upcomingservice= upcomingRentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUpcomingRent()
        {
            var result =  _Upcomingservice.GetUpcomingRent().ToList();
            return Ok(result);
        }
    }
}
