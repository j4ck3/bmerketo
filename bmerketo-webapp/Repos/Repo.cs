using bmerketo_webapp.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bmerketo_webapp.Repos
{
    public abstract class Repo<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;

        public Repo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dataContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predícate)
        {
            var item = await _dataContext.Set<TEntity>().FirstOrDefaultAsync(predícate);
            return item!;
        }



    }
}
