using Domain_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Presentations.Common;
using Service_Layer.Services;
using System.Collections.Generic;

namespace Presentations.Controllers
{
    public class OwnersController : Controller
    {
        private readonly string _sPostEndPoint = "Owners/Add";
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OwnersController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) /*: base(configuration, httpContextAccessor)*/
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        //Seller List View
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpHelper<Owners> httpHelper = new HttpHelper<Owners>(_configuration, _httpContextAccessor);
            var response = httpHelper.GetRequest<ResponseResultAdmin<List<Owners>>>(_sPostEndPoint).Result;
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
        public IActionResult Create(Owners owners) 
        {
            
            HttpHelper<Owners> httpHelper = new HttpHelper<Owners>(_configuration, _httpContextAccessor);
            ResponseResultAdmin<Owners> response = httpHelper.PostRequest<Owners,ResponseResultAdmin<Owners>>(_sPostEndPoint,owners).Result;
            if (response != null)
            {
                TempData["success"] = response;
                return RedirectToAction("Index", "Owners");
                //return View("Index");
            }
            else
            {
                TempData["somthingwentwrong"] = response;
                return View(owners);
            }
        }
    }
}


//Owners owners = new Owners();
////string id = 
//string password = keyValuePairs["password"].ToString();
//string email = keyValuePairs["email"].ToString();
//owners.email = email;
//owners.password = password;

