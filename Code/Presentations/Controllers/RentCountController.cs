using Microsoft.AspNetCore.Mvc;
using Presentations.Common;
using RepositoryLayer.CustomeModel;
using System.Linq;

namespace Presentations.Controllers
{
    public class RentCountController : Controller
    {
        private readonly string _sPostEntPoint = "Rent/Rentcalcuation";
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RentCountController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index(string Amount)
        {
            return View();             
        }
        [HttpPost]
        [Route("RentCount/calculaterent")]
        public JsonResult calculaterent(RentCountModel rentCountModel,string amount)
        {
            HttpHelper<RentCountModel> httpHelper = new HttpHelper<RentCountModel>(_configuration, _httpContextAccessor);
            var responseResult = httpHelper.PostRequest<RentCountModel, ResponseResultAdmin<List<RentCountModel>>>(_sPostEntPoint, rentCountModel).Result;
            return Json(responseResult.Result);
        }

    }
}



//if(propinfo != null)
//{
//    var jsondata = new {date = startdate, enddates = enddate, amounts = amount, payamount = payablemount };
//    return Ok(jsondata);
//}
//else
//{
//    return NotFound();
//}