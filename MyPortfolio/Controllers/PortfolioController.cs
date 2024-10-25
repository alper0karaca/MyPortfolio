using System.Net;
using Business.Concretes;
using DataAccessLayer.Concretes;
using Entities;
using Entities.VM;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());
        
        // GET: PortfolioController
        public ActionResult Index()
        {
            
            ViewBag.v1 = "Portfolio";
            ViewBag.v2 = "Index";
            
            return View();
        }

        
        [HttpGet]
        public IActionResult GetListPortfolio()
        {
            var portfolioList = new List<PortfolioVM>();

            var values = portfolioManager.TGetList();

            foreach (var portfolio in values)
            {
                var portfolioModel = new PortfolioVM()
                {
                    PortfolioId = portfolio.PortfolioId,
                    Title = portfolio.Title,
                    SubTitle = portfolio.SubTitle,
                    ImageUrl = portfolio.ImageUrl,
                    Url = portfolio.Url,
                    Description = portfolio.Description,
                    
                };
                portfolioList.Add(portfolioModel);
            }
            
            return Ok( new { Code = HttpStatusCode.OK, portfolioList});
        }
        
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            portfolioManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }
        
      
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            
            portfolioManager.TUpdate(portfolio);
            
            string message = "Portfolio saved successfully";
            return Ok( new { Code = HttpStatusCode.OK, message});
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = portfolioManager.TGetById(id);
            portfolioManager.TDelete(value);
            
            string message = "Portfolio deleted successfully";
            return Ok( new { Code = HttpStatusCode.OK, message});   
        }



    }
}
