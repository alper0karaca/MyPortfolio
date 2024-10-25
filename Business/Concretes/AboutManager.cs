using Business.Abstracts;
using DataAccessLayer.Abstracts;
using Entities;

namespace Business.Concretes;

public class AboutManager : IAboutService
{
    IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }
    
    public void TAdd(About entity)
    {
        _aboutDal.Add(entity);
    }

    public List<About> TGetList()
    {
        var values = _aboutDal.GetList();
        return values;
    }

    
    public About TGetAbout()
    {
        // burda veritabanı dal katmanında tek veriyi getirecek olan fonk tanımlanacak.

        var about = _aboutDal.GetAbout();
        return about;

    }

    public void TUpdate(About entity)
    {
        
        _aboutDal.Update(entity);
    }

    public void TDelete(About entity)
    {
        _aboutDal.Delete(entity);
    }

    public About TGetById(int id)
    {
        var value = _aboutDal.GetById(id);
        return value;
    }
    
}