using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentations.Common;
using Presentations.Models;
using RepositoryLayer.CustomeModel;

namespace Presentations.Controllers
{
    public class DashboardController : Controller
    {
        private readonly string _sPostEndPoint = "Dashbord";
        //private readonly string _sPostEndPoints = "Tenant/tenantrent";
        private readonly string _sPostEndPoints = "PropertyInfo";
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Index()
        {
            long ownerId = 0;
            string role=string.Empty;
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Session != null)
            {
                ownerId = Convert.ToInt64(_httpContextAccessor.HttpContext.Session.GetString("id"));
                role = _httpContextAccessor.HttpContext.Session.GetString("role");
            }
            HttpHelper<DashbordModel> httpHelper = new HttpHelper<DashbordModel>(_configuration, _httpContextAccessor);
            var dashbord = httpHelper.GetRequest<ResponseResultAdmin<DashbordModel>>(_sPostEndPoint + "?oId=" + ownerId+"&role="+role).Result;
            if (dashbord != null)
            {
                return View(dashbord.Result);
            }
            else
            {
                return NotFound();
            }

        }
        public IActionResult TenantRentCount()
        {
            HttpHelper<Tenant> httpHelper = new HttpHelper<Tenant>(_configuration, _httpContextAccessor);
            var result = httpHelper.GetRequest<ResponseResultAdmin<List<Tenant>>>(_sPostEndPoints).Result;
            if (result != null)
            {
                return View(result.Result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}