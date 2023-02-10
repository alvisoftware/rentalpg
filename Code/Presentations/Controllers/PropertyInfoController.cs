using Domain_Layer.Models;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentations.Common;
using RepositoryLayer.Model;

namespace Presentations.Controllers
{
    [Authorize (Roles ="Owner")]
    public class PropertyInfoController : Controller
    {
        private readonly string _sPostEntPoint = "Propertyinfo";
        //private readonly string _sPostEndPointproperty = "Propertyinfo";
        private readonly string _sPostEntPointowneres = "Owners";
        private readonly string _sPostEntPointcountry = "Country";
        private readonly string _sPostEntPointstate = "StateCode";
        private readonly string _sPostEntPointZip = "ZipCode";
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

            HttpHelper<PropertyInfo> httpHelper = new HttpHelper<PropertyInfo>(_configuration, _httpContextAccessor);
            #region ownerdropdown
            var dropdown = httpHelper.GetRequest<ResponseResultAdmin<List<Owners>>>(_sPostEntPointowneres).Result;
            List<SelectListItem> owners = new List<SelectListItem>();
            if (dropdown.IsSuccess && dropdown.Result != null)
            {
                foreach (var item in dropdown.Result)
                {
                    owners.Add(new SelectListItem() { Text = item.firstname + ' ' + item.lastname, Value = Convert.ToString(item.id) });
                }
            }
            #endregion
            #region Countrydropdown
            var Countrydropdown = httpHelper.GetRequest<ResponseResultAdmin<List<CountryTable>>>(_sPostEntPointcountry).Result;
            List<SelectListItem> country = new List<SelectListItem>();
            List<SelectListItem> cityid = new List<SelectListItem>();
            if (Countrydropdown.IsSuccess && Countrydropdown.Result != null)
            {
                foreach (var item in Countrydropdown.Result)
                {
                    country.Add(new SelectListItem() { Text = item.countryname, Value = Convert.ToString(item.id) });
                }
                foreach (var item in Countrydropdown.Result)
                {
                    cityid.Add(new SelectListItem() { Text = item.cityid.ToString(), Value = Convert.ToString(item.id) });
                }
            }
            #endregion
            #region statedropdown
            var Statedropdown = httpHelper.GetRequest<ResponseResultAdmin<List<StateTable>>>(_sPostEntPointstate).Result;
            List<SelectListItem> state = new List<SelectListItem>();
            if (Statedropdown.IsSuccess && Statedropdown.Result != null)
            {
                foreach (var item in Statedropdown.Result)
                {
                    state.Add(new SelectListItem() { Text = item.statename, Value = Convert.ToString(item.stateid) });
                }
            }
            #endregion
            #region ZipCodedropdown
            var Zipcodedropdown = httpHelper.GetRequest<ResponseResultAdmin<List<ZipCodeTable>>>(_sPostEntPointZip).Result;
            List<SelectListItem> zip = new List<SelectListItem>();
            if (Zipcodedropdown.IsSuccess && Zipcodedropdown.Result != null)
            {
                foreach (var item in Zipcodedropdown.Result)
                {
                    zip.Add(new SelectListItem() { Text = item.zipcode, Value = Convert.ToString(item.id) });
                }
            }
            #endregion
            ViewBag.owners = owners;
            ViewBag.country = country;
            ViewBag.cityid= cityid;
            ViewBag.state = state;
            ViewBag.zip = zip;

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
