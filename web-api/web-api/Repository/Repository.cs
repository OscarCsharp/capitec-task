using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using web_api.Data;

namespace web_api.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly DataContext context;
        private readonly DbSet<TEntity> entities;

        public Repository(DataContext _context)
        {
            context = _context;
            entities = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() => entities;

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await entities.FirstOrDefaultAsync(predicate);
        }

        public async Task Create(TEntity entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }


        public async Task Update(TEntity entity)
        {
            entities.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
