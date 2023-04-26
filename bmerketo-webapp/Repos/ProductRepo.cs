using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Entities;

namespace bmerketo_webapp.Repos
{
    public class ProductRepo : Repo<ProductEntity>
    {
        public ProductRepo(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
