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
                CvUrl = value.CvUrl,
            };

            return Json(new { Code = HttpStatusCode.OK, about });
        }


        // about güncellemesi için 
        [HttpPost]
        public async Task<IActionResult> EditAbout(AboutVM p)
        {
            var existAbout = aboutManager.TGetById(p.AboutId);

            if (p.Cv != null && p.Cv.Length > 0)
            {
                // cv için dosya yolu al
                var directory = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Cv.FileName);
                var pdfName = Guid.NewGuid() + extension;
                var savePath = directory + "/wwwroot/files/" + pdfName;

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await p.Cv.CopyToAsync(stream);
                }

                p.CvUrl = "/files/" + pdfName;
            }
            else
            {
                p.CvUrl = existAbout.CvUrl;
            }

            About about = new About()
            {
                AboutId = p.AboutId,
                Title = p.Title,
                SubDescription = p.SubDescription,
                Details = p.Details,
                CvUrl = p.CvUrl,
            };

            aboutManager.TUpdate(about);

            string message = "Updated Successfully";
            return Json(new { Code = HttpStatusCode.OK, message });
        }

        [HttpPost]
        public IActionResult DeletePdf(int aboutId)
        {
            var existAbout = aboutManager.TGetById(aboutId);


            if (string.IsNullOrEmpty(existAbout.CvUrl))
            {
                string message = "File URL is empty or null";
                //return StatusCode((int)HttpStatusCode.NotFound, message);
                return Ok(new { Code = HttpStatusCode.InternalServerError,message}) ;
            }
            
            var directory = Directory.GetCurrentDirectory();
            var filepath = directory + "/wwwroot" + existAbout.CvUrl;
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
                existAbout.CvUrl = null;
                aboutManager.TUpdate(existAbout);
                return Ok(new { Code = HttpStatusCode.OK, message = "File deleted successfully" });
            }
            else
            {
                return Json(new { error = true, message = "File Not Found" });
            }
        }
    }
}