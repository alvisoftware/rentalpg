using Microsoft.AspNetCore.Mvc;
using Presentations.Models;
using System.Diagnostics;
using Domain_Layer.Models;
using DomainLayer.Models;
using Presentations.Common;

namespace Presentations.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _sPostEndpoint = "User/Authenticate";
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View(new UserRole());
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel usersModel)
        {
            HttpHelper<UserModel> httpHelper = new HttpHelper<UserModel>(_configuration, _httpContextAccessor);
            var response = httpHelper.PostRequest<UserModel,ResponseResultAdmin<string> >(_sPostEndpoint, usersModel).Result;
            return View(response);
            //if (response != null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    return View();
            //}
        }

    }
}