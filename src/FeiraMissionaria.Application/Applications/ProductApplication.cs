using AutoMapper;
using FeiraMissionaria.Application.Interfaces;
using FeiraMissionaria.Application.Models.Product;
using FeiraMissionaria.Domain.Entities;
using FeiraMissionaria.Domain.Repositories;

namespace FeiraMissionaria.Application.Applications;
public class ProductApplication : IProductApplication
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public ProductApplication(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ProductModel> CreateAsync(PostProductModel model)
    {
        var entity = await _repository.CreateAsync(_mapper.Map<Product>(model));

        return _mapper.Map<ProductModel>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<ProductModel>>(entities);
    }

    public async Task<ProductModel> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return _mapper.Map<ProductModel>(entity);
    }

    public async Task UpdateAsync(PostProductModel model, Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        await _repository.UpdateAsync(_mapper.Map<PostProductModel, Product>(model, entity));        
    }
}
