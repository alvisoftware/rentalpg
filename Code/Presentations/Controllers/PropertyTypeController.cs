using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentations.Controllers
{
    public class PropertyTypeController : Controller
    {
        //PropertyType List View
        public IActionResult Index()
        {
            var proplist = new List<PropertyType>();
            return View(proplist);
        }
    }
}
