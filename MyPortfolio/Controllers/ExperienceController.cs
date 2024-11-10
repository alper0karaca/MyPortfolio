using System.Net;
using Business.Concretes;
using DataAccessLayer.Concretes;
using Entities;
using Entities.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        // GET: ExperienceController
        public ActionResult Index()
        {
            ViewBag.v1 = "Experience";
            ViewBag.v2 = "Index";
            
            return View();
        }
        
        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Experience";
            ViewBag.v2 = "Add Experience";
            
            return View();
        }

        public IActionResult GetListExperience()
        {
            var experienceList = new List<ExperienceVM>();
            var values = experienceManager.TGetList();

            foreach (var experience in values)
            {
                var experienceModal = new ExperienceVM()
                {
                    ExperienceId = experience.ExperienceId,
                    Head = experience.Head,
                    Title = experience.Title,
                    Date = experience.Date,
                    Description = experience.Description,
                };
                experienceList.Add(experienceModal);
            }

            return Ok(new { Code = HttpStatusCode.OK, experienceList });
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return Ok( new {Code = HttpStatusCode.OK, Message = "Experience Added Successfully"});
        }
        
        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return Ok( new {Code = HttpStatusCode.OK, Message = "Experience Updated"});
            
        }
        
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetById(id);
            experienceManager.TDelete(values);
            return Ok( new {Code = HttpStatusCode.OK, Message = "Experience Deleted"});

        }

    }
}
