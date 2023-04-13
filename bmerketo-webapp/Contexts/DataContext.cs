using bmerketo_webapp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace bmerketo_webapp.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
