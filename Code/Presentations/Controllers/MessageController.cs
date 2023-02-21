using ApiLayer.Controllers;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentations.Common;
using Presentations.Models;
using RepositoryLayer.CustomeModel;

namespace Presentations.Controllers
{
    public class MessageController : Controller
    {
        private readonly string _sPostEndPoint = "MessageMaster";
        //private readonly string _sPostEndPoints = "MesageDetails";
        private readonly string _sPostEndPointProperty = "PropertyInfo";
        private readonly IConfiguration _configuration;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public MessageController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            HttpHelper<MesssageMaster> httpHelper = new HttpHelper<MesssageMaster>(_configuration, _httpContextAccessor);
            #region propertydropdown
            var dropdown = httpHelper.GetRequest<ResponseResultAdmin<List<PropertyInfo>>>(_sPostEndPointProperty).Result;
            List<SelectListItem> objlist = new List<SelectListItem>();
            if(dropdown.IsSuccess && dropdown.Result != null)
            {
                foreach(var item in dropdown.Result)
                {
                    objlist.Add(new SelectListItem() { Text = item.name, Value = Convert.ToString(item.id)});
                }
            }
            #endregion
            ViewBag.property = objlist;

            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormCollection keyValuePairs)
        {
            CommonMessage commonMessage = new CommonMessage();
            string[] selectpropertyid = keyValuePairs["ddlpropertylist"].ToString().Split(',');
            string message = keyValuePairs["mesgbox"];
            long tenantid = 0;
            string role = string.Empty;
            if(_httpContextAccessor.HttpContext !=null&&_httpContextAccessor.HttpContext.Session != null)
            {
                tenantid = Convert.ToInt64(_httpContextAccessor.HttpContext.Session.GetString("id"));
            }
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Session != null) 
            {
                role =  _httpContextAccessor.HttpContext.Session.GetString("role");
            }
            commonMessage.propertyid = Convert.ToInt32(selectpropertyid[0]);
            commonMessage.message = message;
            commonMessage.tenantid = tenantid;
            commonMessage.role = role;
            
            HttpHelper<CommonMessage> httpHelper = new HttpHelper<CommonMessage>(_configuration, _httpContextAccessor);
            var result = httpHelper.PostRequest<CommonMessage, ResponseResultAdmin<CommonMessage>>(_sPostEndPoint, commonMessage).Result;
            
            if (result != null )
            {
                TempData["Success"] = result;
                return RedirectToAction("Index", "Message");
            }
            else
            {
                TempData["Somthing Went Wrong"] = Response;
                return View(result);
            }
        }
    }
}
