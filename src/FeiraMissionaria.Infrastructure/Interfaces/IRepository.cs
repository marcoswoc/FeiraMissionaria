using System.Linq.Expressions;

namespace FeiraMissionaria.Infrastructure.Interfaces;
public interface IRepository<TEntity> where TEntity : IEntity
{    
   
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid Id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(Guid Id);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> expression);
    IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> expression);
}
