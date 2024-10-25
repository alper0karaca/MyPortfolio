using Entities;

namespace Business.Abstracts;

public interface IAboutService : IGenericService<About>
{
    public About TGetAbout();
}