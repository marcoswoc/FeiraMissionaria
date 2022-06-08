using FeiraMissionaria.Application;
using Microsoft.Extensions.DependencyInjection;

namespace FeiraMissionaria.WebApi.Core.Extensions;
public static class AutoMapperExtensions
{
    public static void AddFeiraMissionariaAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config => config.AddProfile<MapperProfile>());
    }
}
