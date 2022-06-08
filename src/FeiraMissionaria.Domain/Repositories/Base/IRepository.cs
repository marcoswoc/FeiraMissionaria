using FeiraMissionaria.Domain.Entities.Base;
using System.Linq.Expressions;

namespace FeiraMissionaria.Domain.Repositories.Base;
public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid Id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    Task DeleteAsync(Guid Id);
}
