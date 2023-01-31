using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentations.Controllers
{
    public class InquiryController : Controller
    {
        //inquiry list view
        public IActionResult Index()
        {
            var inq = new List<Inquiry>();
            return View(inq);
        }
    }
}
