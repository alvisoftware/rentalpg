using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentations.Controllers
{
    public class CategoryController : Controller
    {
        //category List View
        public IActionResult Index()
        {
            var cat = new List<Category>();
            return View(cat);
        }
    }
}
