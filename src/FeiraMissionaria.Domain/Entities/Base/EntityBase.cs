using System.ComponentModel.DataAnnotations;

namespace FeiraMissionaria.Domain.Entities.Base;
public abstract class EntityBase : IEntity, IAuditable
{
    [Key]
    public virtual Guid Id { get; set; } = Guid.NewGuid();
    public virtual DateTime? CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }

    protected EntityBase() { }
}
