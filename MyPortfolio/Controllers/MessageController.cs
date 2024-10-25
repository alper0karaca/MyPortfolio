using System.Net;
using Business.Concretes;
using DataAccessLayer.Concretes;
using Entities;
using Entities.VM;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        
        public IActionResult Inbox()
        {
            ViewBag.v1 = "Message";
            ViewBag.v2 = "Inbox";
            return View();
        }

        // alper yeni mesaj listesi yazımı
        [HttpGet]
        public IActionResult GetAllMessages()
        {
            
            if (messageManager == null)
            {
                return StatusCode(500, "MessageManager is null.");
            }

            var allMessages = messageManager.TGetList();
            if (allMessages == null)
            {
                return StatusCode(500, "No messages found.");
            }
            
            var messageList = new List<MessageVM>();

            foreach (var message in allMessages)
            {
                var messageListModel = new MessageVM()
                {
                    MessageId = message.MessageId,
                    NameSurname = message.NameSurname,
                    Subject = message.Subject,
                    Email = message.Email,
                    MessageDetail = message.MessageDetail,
                    SendDate = message.SendDate,
                    IsRead = message.IsRead,
                };
                messageList.Add(messageListModel);
            }

            return Ok(new { Code = HttpStatusCode.OK, messageList });
        }


        [HttpPost]
        public IActionResult UpdateMessage(int id)
        {
            var value = messageManager.TGetById(id);

            if (value.IsRead)
            {
                value.IsRead = false;
            }
            else
            {
                value.IsRead = true;
            }
            
            messageManager.TUpdate(value);
            
            return Ok( new { Code = HttpStatusCode.OK, Message = "Message has been updated" });
        }

        [HttpGet]
        public IActionResult DeleteMessage(int id)
        {
            var value =messageManager.TGetById(id);
            messageManager.TDelete(value);

            return Ok(new { Code = HttpStatusCode.OK, Message = "Message has been deleted" });
        }

        [HttpGet]
        public IActionResult MessageDetail(int id)
        {
            
            var value = messageManager.TGetById(id);

            if (value == null)
            {
                return NotFound();
            }
            
            return Json( new { 
                nameSurname = value.NameSurname,
                subject = value.Subject,
                email = value.Email,
                messageDetail = value.MessageDetail,
                sendDate = value.SendDate,
            });
            return View(value);
            
        }

    }
}
