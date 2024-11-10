using DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        MyPortfolioContext _context = new MyPortfolioContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.v1 = "Dashboard";
            ViewBag.v2 = "Index";
            
            // yetenek sayısı 
            ViewBag.skillCount = _context.Skills.Count(); 
            // deneyim sayısı
            ViewBag.experienceCount = _context.Experiences.Count();
            // okunan
            ViewBag.readMessage = _context.Messages.Where(x => x.IsRead == true).ToList().Count;
            // Okunmayan mesajlar
            ViewBag.unReadMessage = _context.Messages.Where(x => x.IsRead == false).ToList().Count;
            // proje sayısı
            ViewBag.portfolioCount = _context.Portfolios.Count();
            
            // istatistikl değerlerini gösteren kartlar gelecek
            return View();
        }

    }
}
