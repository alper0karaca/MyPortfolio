using Business.Concretes;
using DataAccessLayer.Concretes;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents;

public class _AboutComponentPartial : ViewComponent
{
    AboutManager aboutManager = new AboutManager(new EfAboutDal());
    public IViewComponentResult Invoke()
    {
        // cv url almamız lazım
        var value = aboutManager.TGetAbout();
        return View(value);
    }

}