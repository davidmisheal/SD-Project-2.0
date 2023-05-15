using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.acsses = HttpContext.Session.GetString("acsses");
            var Email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }
            return View();
        }
        
        public IActionResult Booking()
		{
            ViewBag.acsses = HttpContext.Session.GetString("acsses");
            var Email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(Email))
            {
                return View();
            }
            return View();
		}
    }
}
