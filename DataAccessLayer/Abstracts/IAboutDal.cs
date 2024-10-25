using Entities;

namespace DataAccessLayer.Abstracts;

public interface IAboutDal : IGenericDal<About>
{
    public About GetAbout();

}