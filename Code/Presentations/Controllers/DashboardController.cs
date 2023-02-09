using Domain_Layer.Data;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentations.Common;
using Presentations.Models;
using RepositoryLayer.CustomeModel;

namespace Presentations.Controllers
{
    public class DashboardController : Controller
    {
        private readonly string _sPostEndPoint = "Dashbord";
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
                DashbordModel result = new DashbordModel
                {
                    property = 3,
                    avilable=4,
                    rent=2,
                    upcomingrent=2
                };
                ViewData["myproduct"] = result;
                return View(dashbord.Result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}



////var result = _applicationDbContext.propertyInfos.GroupBy(n => n.propertytypeid)
////            .Select(g => new { CategoryName = g.Key, Count = g.Count() }).ToList();
////List<PropertyInfo> propList = new List<PropertyInfo>();
////for (int i = 0; i < result.ToList().Count; i++)
////{
////    propList.Add(new PropertyInfo { id = result[i].CategoryName, count= result[i].Count });
////}
////return View(propList);
//return View();


//PropertyInfo propertyInfo = new DomainLayer.Models.PropertyInfo();
//propertyInfo.id = 1;
//propertyInfo.name = "abc";
//propertyInfo.name = "def";
//propertyInfo.name = "xyz";

//var result = _applicationDbContext.propertyInfos
//.Include("PropertyInfos")
//.ToList()
//.GroupBy(e => e.propertytypeid)
//.Select(y => new 
//{
//    Department = y.First().propertytypeid,
//    count = y.Count()
//}).ToList();
//List<PropertyInfo> properties = new List<PropertyInfo>();
//for (int i = 0; i < result.ToList().Count; i++)
//{
//    properties.Add(new PropertyInfo { propertytypeid = result[i].count});
//}
//return View(properties);


//return View();
//var result = _applicationDbContext.propertyInfos.Include("Total").Select
//(pg => new
//{
//    Total = pg.name.Count()
//}).ToList();
//foreach (var property in result)
//{
//    properties.Add(new PropertyInfo()
//    {

//    });
//}

//return View(result);