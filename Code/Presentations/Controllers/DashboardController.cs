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
            HttpHelper<DashbordModel> httpHelper = new HttpHelper<DashbordModel>(_configuration, _httpContextAccessor);
            var dashbord = httpHelper.GetRequest<ResponseResultAdmin<List<DashbordModel>>>(_sPostEndPoint).Result;
            if (dashbord != null)
            {
                List<UpcomingRent> upcomingRents = new List<UpcomingRent>
                {
                    new UpcomingRent
                    {
                        propertytitle = "Ace Real Estate",
                        tenantname ="Silas Tenant",
                        startDate = Convert.ToDateTime("01/02/2023"),
                        endDate = Convert.ToDateTime("10/02/2023"),
                        rentamount = "1000",
                        status = "active"
                    },
                    new UpcomingRent
                    {
                        propertytitle = "Real Estate",
                        tenantname ="Joseph Tenant",
                        startDate = Convert.ToDateTime("02/02/2023"),
                        endDate = Convert.ToDateTime("12/02/2023"),
                        rentamount = "1500",
                        status = "active"
                    },
                    new UpcomingRent
                    {
                        propertytitle = "Kale Realty",
                        tenantname ="Mary Smith",
                        startDate = Convert.ToDateTime("02/08/2023"),
                        endDate = Convert.ToDateTime("02/20/2023"),
                        rentamount = "1700",
                        status = "active"
                    }
                };
                ViewBag.property = upcomingRents;
                DashbordModel result = new DashbordModel
                {
                    property = 3,
                    avilable = 4,
                    rent = 2,
                    //upcomingrent = 
                };
                ViewData["myproduct"] = result;
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