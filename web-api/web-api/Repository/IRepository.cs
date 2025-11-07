using System.Linq.Expressions;

namespace web_api.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll() ;
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        void Dispose();
    }
}
