using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentations.Common;

namespace Presentations.Controllers
{
    public class AssignedController : Controller
    {
        private readonly string _sPostEndPoint = "Assigned/Insert";
        private readonly string _sPostEndPointProperty = "PropertyInfo";
        private readonly string _sPostEndPointTenant = "Tenant";
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
            HttpHelper<AssignedProperties> httpHelper = new HttpHelper<AssignedProperties>(_configuration, _httpContextAccessor);
            #region Property DropDown
            var dropdownresult = httpHelper.GetRequest<ResponseResultAdmin<List<PropertyInfo>>>(_sPostEndPointProperty).Result;
            List<SelectListItem> ObjList = new List<SelectListItem>();
            if(dropdownresult.IsSuccess && dropdownresult.Result != null)
            {
                foreach(var item in dropdownresult.Result)
                {
                    ObjList.Add(new SelectListItem() { Text = item.name, Value=Convert.ToString(item.id)+","+Convert.ToString(item.ownerid)});
                }
            }
            #endregion
            #region tenant dropdown
            var dropdowntenant = httpHelper.GetRequest<ResponseResultAdmin<List<Tenant>>>(_sPostEndPointTenant).Result;
            List<SelectListItem> tenant = new List<SelectListItem>();
            if (dropdowntenant.IsSuccess && dropdowntenant.Result != null)
            {
                foreach (var item in dropdowntenant.Result)
                {
                    tenant.Add(new SelectListItem() { Text = item.firsttname+' '+item.lasttname,Value=Convert.ToString(item.id)});
                }
            }
            #endregion
            #region Transtype DropDown
            //var dropdowntrans = httpHelper.GetRequest<ResponseResultAdmin<List<PropertyInfo>>>(_sPostEndPoint).Result;
            //List<SelectListItem> trans = new List<SelectListItem>();
            //if (dropdowntrans.IsSuccess && dropdowntrans.Result != null)
            //{
            //    foreach (var item in dropdowntrans.Result)
            //    {
            //        ObjList.Add(new SelectListItem() { Text = item.transtpetype.ToString() });
            //    }
            //}
            #endregion
            ViewBag.Locations = ObjList;
            ViewBag.tenant = tenant;
            //ViewBag.trans = trans;
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection keyValuePairs)
        {
            RentMaster rentMaster = new RentMaster();
            string[] selectedpropertyid = keyValuePairs["ddlpropertylist"].ToString().Split(",");
            string tenantdropdown = keyValuePairs["ddltenant"].ToString();
            DateTime startdatevalue = Convert.ToDateTime(keyValuePairs["dtstartdate"]);
            DateTime enddatevalue = Convert.ToDateTime(keyValuePairs["dtenddate"]);
            string amount = keyValuePairs["txtamount"];
            rentMaster.propertyid = Convert.ToInt64(selectedpropertyid[0]);
            rentMaster.ownerid = Convert.ToInt64(selectedpropertyid[1]);
            rentMaster.tenantid = Convert.ToInt64(tenantdropdown);
            rentMaster.startdate = Convert.ToDateTime(startdatevalue);
            rentMaster.enddate = Convert.ToDateTime(enddatevalue);
            rentMaster.amount = amount;
           
            //1 add assginedpropertes


            HttpHelper<RentMaster>  httpHelper = new HttpHelper<RentMaster>(_configuration, _httpContextAccessor);
            ResponseResultAdmin<RentMaster> result = httpHelper.PostRequest<RentMaster, ResponseResultAdmin<RentMaster>>(_sPostEndPoint,rentMaster).Result;
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



