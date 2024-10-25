using System.Net;
using Business.Concretes;
using DataAccessLayer.Concretes;
using Entities;
using Entities.VM;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        private AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            ViewBag.v1 = "About";
            ViewBag.v2 = "Index";
            
            return View();
        }

        public IActionResult GetAbout()
        {
            // burada about için VM oluştur onu döndür
            
            var value = aboutManager.TGetAbout();
            // normalde burda Enumstan gelen status değeri başarılı durumu kontrol edilir.
            var about = new AboutVM()
            {
                AboutId = value.AboutId,
                Title = value.Title,
                SubDescription = value.SubDescription,
                Details = value.Details,
            };

            return Json(new { Code = HttpStatusCode.OK, about});
        }
        
        
        
        // about güncellemesi için 
        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            
            aboutManager.TUpdate(about);

            string message = "Updated Successfully";
            return Json(new {Code = HttpStatusCode.OK, message });
        }
        
    }
}
