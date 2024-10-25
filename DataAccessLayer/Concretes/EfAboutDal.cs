using DataAccessLayer.Abstracts;
using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using Entities;

namespace DataAccessLayer.Concretes;

public class EfAboutDal : GenericRepository<About>, IAboutDal
{
    MyPortfolioContext  context = new MyPortfolioContext();
    public About GetAbout()
    {
       var value = context.Abouts.SingleOrDefault();

       return value;
    }
}