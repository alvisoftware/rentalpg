using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Presentations.Common;
using RepositoryLayer.Model;

namespace Presentations.Controllers
{
    public class PropertyInfoController : Controller
    {
        private readonly string _sPostEntPoint = "Propertyinfo/PropertyListWithOwner";
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
            HttpHelper<PropertyInfo> httpHelper = new HttpHelper<PropertyInfo>(_configuration, _httpContextAccessor);
            var propinfo = httpHelper.GetRequest<ResponseResultAdmin<List<PropertyInfo>>>(_sPostEntPoint).Result;
            if(propinfo != null)
            {
                return View(propinfo.Result);
            }
            else
            {
                return NotFound();  
            }
        }
        public async Task<IActionResult> Propertylist()
        {
            HttpHelper<PropertyModel> httpHelper = new HttpHelper<PropertyModel>(_configuration, _httpContextAccessor);
            var propinfo = httpHelper.GetRequest<ResponseResultAdmin<List<PropertyModel>>>(_sPostEntPoint).Result;
            if (propinfo != null)
            {
                return View(propinfo.Result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PropertyInfo propertyInfo)
        {
            HttpHelper<PropertyInfo> httpHelper = new HttpHelper<PropertyInfo>(_configuration, _httpContextAccessor);
            ResponseResultAdmin<PropertyInfo> result = httpHelper.PostRequest<PropertyInfo,ResponseResultAdmin<PropertyInfo>>(_sPostEntPoint,propertyInfo).Result;
            if(result!= null)
            {
                TempData["success"] = result;
                return RedirectToAction("Index", "PropertyInfo");
            }
            else
            {
                TempData["Somthing Went Wrong"] = Response;
                return View(result);
            }
        }
    }
}
