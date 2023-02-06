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
        public IActionResult Login(UserModel userModel)
        {
            HttpHelper<UserModel> httpHelper = new HttpHelper<UserModel>(_configuration, _httpContextAccessor);
            var response = httpHelper.PostRequest<UserModel, ResponseResultAdmin<string>>(_sPostEndpoint, userModel).Result;

            if (response != null && response.Result != null)
            {
                var claims = new List<Claim>
                 {
                     new Claim(ClaimTypes.Name, userModel.userName),
                 };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
            //return View(response);
        }

    }
}