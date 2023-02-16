using Microsoft.AspNetCore.Mvc;
using Presentations.Models;
using System.Diagnostics;
using Domain_Layer.Models;
using DomainLayer.Models;
using Presentations.Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using static DomainLayer.Models.Users;
using Microsoft.AspNetCore.Identity;

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
        [HttpGet]

        public IActionResult Index()
        {
            var claims = HttpContext.User.Claims;
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public IActionResult Login(Users users)
        {
            HttpHelper<Users> httpHelper = new HttpHelper<Users>(_configuration, _httpContextAccessor);
            var response = httpHelper.PostRequest<Users, ResponseResultAdmin<UserModel>>(_sPostEndpoint, users).Result;
            if (response != null && response.Result != null)
            {
                HttpContext.Session.SetString("username", response.Result.userName.ToString());
                HttpContext.Session.SetString("role", response.Result.role.ToString());
                HttpContext.Session.SetString("id", response.Result.id.ToString());
                HttpContext.Session.SetString("token", response.Result.token.ToString());
                HttpContext.Session.SetString("role", response.Result.role.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

    }
}