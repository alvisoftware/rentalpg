using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentations.Common;

namespace Presentations.Controllers
{
    public class AssignedController : Controller
    {
        private readonly string _sPostEndPoint = "Assigned";
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public AssignedController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Create()
        {
            HttpHelper<Subtable> httpHelper = new HttpHelper<Subtable>(_configuration, _httpContextAccessor);
            //Property DropDown
            var dropdownresult = httpHelper.GetRequest<ResponseResultAdmin<List<PropertyInfo>>>(_sPostEndPoint).Result;
            List<SelectListItem> ObjList = new List<SelectListItem>();
            if(dropdownresult.IsSuccess && dropdownresult.Result != null)
            {
                foreach(var item in dropdownresult.Result)
                {
                    ObjList.Add(new SelectListItem() { Text = item.name});
                }
            }
            //tenant dropdown
            var dropdowntenant = httpHelper.GetRequest<ResponseResultAdmin<List<Tenant>>>(_sPostEndPoint).Result;
            List<SelectListItem> tenant = new List<SelectListItem>();
            if (dropdowntenant.IsSuccess && dropdowntenant.Result != null)
            {
                foreach (var item in dropdowntenant.Result)
                {
                    ObjList.Add(new SelectListItem() { Text = item.firsttname+' '+item.lasttname });
                }
            }
            //Transtype DropDown
            var dropdowntrans = httpHelper.GetRequest<ResponseResultAdmin<List<PropertyInfo>>>(_sPostEndPoint).Result;
            List<SelectListItem> trans = new List<SelectListItem>();
            if (dropdowntrans.IsSuccess && dropdowntrans.Result != null)
            {
                foreach (var item in dropdowntrans.Result)
                {
                    ObjList.Add(new SelectListItem() { Text = item.transtpetype.ToString() });
                }
            }
            ViewBag.Locations = ObjList;
            ViewBag.tenant = tenant;
            ViewBag.trans = trans;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subtable subtable)
        {
            HttpHelper<Subtable>  httpHelper = new HttpHelper<Subtable>(_configuration, _httpContextAccessor);
            ResponseResultAdmin<Subtable> result = httpHelper.PostRequest<Subtable, ResponseResultAdmin<Subtable>>(_sPostEndPoint, subtable).Result;
            if(result != null) 
            {
                TempData["Success"] = result;
                return RedirectToAction("Index","PropertyInfo");
            }
            else
            {
                TempData["Somthing Went Wrong"] = Response;
                return View(result);
            }
        }
    }
}



//{
//    new SelectListItem { Text="Luxury villa in hinterland",Value="1"},
//    new SelectListItem { Text="Mesa Ridge",Value="2"},
//    new SelectListItem { Text="Villa on Hartford",Value="3" },
//    new SelectListItem { Text="Bay view Apartment 1",Value="4"},
//};
//List<SelectListItem> tenant = new List<SelectListItem>()
//{
//    new SelectListItem { Text="Johan Smith",Value="1"},
//    new SelectListItem { Text="Brucly",Value="2"},
//    new SelectListItem { Text="Harry potter",Value="3" },
//    new SelectListItem { Text="Jimy Jorden",Value="4"},
//};