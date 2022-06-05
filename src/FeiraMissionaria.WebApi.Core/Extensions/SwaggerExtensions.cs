using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FeiraMissionaria.WebApi.Core.Extensions;
public static class SwaggerExtensions
{
    public static void AddFeiraMissionariaSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Acesso protegido utilizando o accessToken obtido em \"api/Authenticate/login\""
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
     }
}
