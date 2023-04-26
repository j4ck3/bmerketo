using bmerketo_webapp.Contexts;
using bmerketo_webapp.Models.Entities;

namespace bmerketo_webapp.Repos
{
    public class ProductCategoryRepo : Repo<ProductCategoryEntity>
    {
        public ProductCategoryRepo(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
