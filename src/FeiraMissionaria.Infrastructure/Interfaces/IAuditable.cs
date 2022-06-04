namespace FeiraMissionaria.Infrastructure.Interfaces;
public interface IAuditable
{
    DateTime? CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    DateTime? DeletedAt { get; set; }
}
