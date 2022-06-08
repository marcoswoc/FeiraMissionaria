using FeiraMissionaria.Domain.Repositories;
using FeiraMissionaria.Persistence.Contexts;
using FeiraMissionaria.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeiraMissionaria.WebApi.Core.Extensions;
public static class ContextExtensions
{
    public static void AddFeiraMissionariaDbContext(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<FeiraMissionariaDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(configuration["FeiraMissionariaConnection"]));
        });
    }

    public static void AddFeiraMissionariaIdentity(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<FeiraMissionariaDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void AddFeiraMissionariaRepositories(this IServiceCollection service)
    {
        service.AddScoped<IProductRepository, ProductRepository<FeiraMissionariaDbContext>>();
    }
}
