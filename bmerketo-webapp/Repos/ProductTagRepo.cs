using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Entities;

namespace bmerketo_webapp.Repos
{
    public class ProductTagRepo : Repo<ProductTagEntity>
    {
        public ProductTagRepo(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
