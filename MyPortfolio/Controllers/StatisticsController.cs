using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticsController : Controller
    {
        
        // GET: StatisticsController
        public ActionResult Index()
        {
            return View();
        }

    }
}
