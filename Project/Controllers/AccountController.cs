using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDBcontext _dbcontext;
        public AccountController(ApplicationDBcontext context)
        {
            _dbcontext = context;
        }
        [HttpGet]
        public IActionResult Signin()
        {
            return View(new User());
        }
        public JsonResult IsEmailExist(string Email)
        {
            return Json(data:!_dbcontext.Users.Any(u => u.Email == Email));
        }
        [HttpPost]
        public IActionResult Signin(User user)
        {
            var isEmailExist = _dbcontext.Users.Any(u => u.Email == user.Email);
            if (ModelState.IsValid)
            {
                if (isEmailExist)
                {
                    // Add an error message to the view model.
                    ModelState.AddModelError("Email", "This email address is already registered.");
				}
				else
				{
                    _dbcontext.Users.Add(user);
                    _dbcontext.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
               
            }
            return View(user);

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(String Email , String Password)
        {
            if (ModelState.IsValid)
            {
                var user = _dbcontext.Users.FirstOrDefault(u => u.Email == Email);
                if (user != null)
                {
                    if (user.Password == Password)
                    {
                        HttpContext.Session.SetString("acsses", user.Email);
                        return RedirectToAction("Index", "Main");
                    }

                    else
                    {
                        ModelState.AddModelError("Password", "Invalid email or password");
                    }
                }
                else if (user == null)
                {
                    var admin = _dbcontext.Admins.FirstOrDefault(u => u.Email == Email);
                    if (admin!= null && admin.Password == Password)
                    {
                        HttpContext.Session.SetString("acsses", "Admin");
                        return RedirectToAction("Index", "Main");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Invalid email or password");
                    }
                }      
            }
            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Main");
        }
    }
    
}


