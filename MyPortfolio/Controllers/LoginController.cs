using System.Security.Claims;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyPortfolio.Controllers
{
    public class LoginController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);

            if (user != null)
            {
                string userRoleName = user.UserRoleId switch
                {
                    1 => "Admin",
                    2 => "User",
                    _ => "Guest"
                };
                
                // kulllanıc bilgilerini ve rolünü cookiye ekleme
                var claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, userRoleName)
                };

                var claimsIdentity = new ClaimsIdentity(claim, "AdminCookie");
                await HttpContext.SignInAsync("AdminCookie", new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Dashboard");

            }

            ViewBag.Error = "Username or password is incorrect.";
            return View();

        }

        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("AdminCookie");
            return RedirectToAction("Index", "Login");
        }

    }
}
