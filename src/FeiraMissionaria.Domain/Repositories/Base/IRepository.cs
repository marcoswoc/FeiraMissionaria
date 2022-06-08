using FeiraMissionaria.Domain.Entities.Base;
using System.Linq.Expressions;

namespace FeiraMissionaria.Domain.Repositories.Base;
public interface IRepository<TEntity> where TEntity : IEntity
{

    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid Id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid Id);
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
}
