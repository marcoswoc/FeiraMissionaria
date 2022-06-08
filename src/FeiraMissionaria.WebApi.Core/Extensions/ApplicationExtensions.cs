using FeiraMissionaria.Application.Applications;
using FeiraMissionaria.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FeiraMissionaria.WebApi.Core.Extensions;
public static class ApplicationExtensions
{

    public static void AddFeiraMissionariaApplications(this IServiceCollection services)
    {
        services.AddScoped<IProductApplication, ProductApplication>();
    }
}
