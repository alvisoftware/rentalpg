using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Presentations.Common;

namespace Presentations.Controllers
{
    public class TenantController : Controller
    {
        private readonly string _sPostEndPoint = "Tenant";
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TenantController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        //Tenant list view
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpHelper<Tenant> httpHelper = new HttpHelper<Tenant>(_configuration, _httpContextAccessor);
            var response = httpHelper.GetRequest<ResponseResultAdmin<List<Tenant>>>(_sPostEndPoint).Result;
            if (response != null)
            {
                return View(response.Result);
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
        public IActionResult Create(Tenant tenant)
        {
            HttpHelper<Tenant> httpHelper = new HttpHelper<Tenant>(_configuration, _httpContextAccessor);
            ResponseResultAdmin<Tenant> response = httpHelper.PostRequest<Tenant,ResponseResultAdmin<Tenant>>(_sPostEndPoint, tenant).Result;
            if (response != null)
            {
                TempData["Success"] = response;
                return View("index");
            }
            else
            {
                TempData["SomthingWentWrong"] = response;
                return View(tenant);
            }
        }
    }
}
