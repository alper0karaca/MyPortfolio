using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents;

public class _AboutComponentPartial : ViewComponent
{
    MyPortfolioContext context = new MyPortfolioContext();
    
    public IViewComponentResult Invoke()
    {

        return View();
    }

}