using DomainLayer.Models;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Presentations.Common;

namespace Presentations.Controllers
{
    public class PropertyInfoController : Controller
    {
        private readonly string _sPostEntPoint = "Propertyinfo";
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PropertyInfoController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        
        //PropertyInfo List View
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            HttpHelper<ResponseModel> httpHelper = new HttpHelper<ResponseModel>(_configuration, _httpContextAccessor);
            var propinfo = httpHelper.GetRequest<ResponseResultAdmin<List<ResponseModel>>>(_sPostEntPoint).Result;
            if(propinfo != null)
            {
                return View(propinfo.Result);
            }
            else
            {
                return View();  
            }
        }
      
    }
}
