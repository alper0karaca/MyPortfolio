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
    public class FeatureController : Controller
    {
        
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        
        public ActionResult Index()
        {
            ViewBag.v1 = "Feature";
            ViewBag.v2 = "Index";
            return View();
        }

        [HttpGet]
        public IActionResult GetFeature()
        {
            var featureList = new List<FeatureVM>();
            var features = featureManager.TGetList();

            foreach (var feature in features)
            {
                var featureListModel = new FeatureVM()
                {
                    FeatureId = feature.FeatureId,
                    Title = feature.Title,
                    Description = feature.Description,
                };
                
                featureList.Add(featureListModel);
            }
            
            return Ok( new { Code = HttpStatusCode.OK, featureList});
            
            
        }
        
        [HttpPost]
        public IActionResult EditFeature(Feature feature)
        {
            featureManager.TUpdate(feature);
            var message = "Feature updated successfully";
            return Ok( new {Code = HttpStatusCode.OK, message});
        }
        
    }
}
