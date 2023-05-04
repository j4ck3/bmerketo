using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Entities;

namespace bmerketo_webapp.Repos;

public class TagRepo : Repo<TagEntity>
{
    public TagRepo(DataContext dataContext) : base(dataContext)
    {
    }
}
