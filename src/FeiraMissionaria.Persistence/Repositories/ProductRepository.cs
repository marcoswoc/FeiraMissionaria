using FeiraMissionaria.Domain.Entities;
using FeiraMissionaria.Domain.Repositories;
using FeiraMissionaria.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FeiraMissionaria.Persistence.Repositories;
public class ProductRepository<TContext> : RepositoryBase<Product>, IProductRepository
    where TContext : DbContext
{
    public ProductRepository(TContext context) : base(context) { }
}
