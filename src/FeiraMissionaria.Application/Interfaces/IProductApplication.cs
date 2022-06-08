using FeiraMissionaria.Application.Models.Product;

namespace FeiraMissionaria.Application.Interfaces;
public interface IProductApplication
{
    Task<ProductModel> CreateAsync(PostProductModel model);
    Task<ProductModel> GetByIdAsync(Guid id);
    Task<IEnumerable<ProductModel>> GetAllAsync();
    Task UpdateAsync(PostProductModel model, Guid id);
    Task DeleteAsync(Guid id);
}
