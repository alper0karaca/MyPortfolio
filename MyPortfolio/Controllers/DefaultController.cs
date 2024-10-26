using Business.Concretes;
using DataAccessLayer.Concretes;
using DataAccessLayer.Context;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: DefaultController
        public IActionResult Index()
        {            
            var values = aboutManager.TGetList().FirstOrDefault();

            ViewBag.aboutTitle = values.Title;
            ViewBag.aboutSubDescription = values.SubDescription;
            ViewBag.aboutDetails = values.Details;
            
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.SendDate = DateTime.Now;
                message.IsRead = false;
                messageManager.TAdd(message);
                
                return Json(new {success = true, message = "Your message was sent successfully!"});
            }
            else
            {
                return Json(new {success = false, message = "Your message was not sent. Please fill in the form correctly!"});
            }
            
        }

    }
}
