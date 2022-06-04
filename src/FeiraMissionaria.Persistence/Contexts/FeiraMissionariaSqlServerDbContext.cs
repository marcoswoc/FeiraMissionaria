using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FeiraMissionaria.Persistence.Contexts;
public class FeiraMissionariaSqlServerDbContext : FeiraMissionariaDbContext
{
    private readonly IConfiguration _configuration;

    public FeiraMissionariaSqlServerDbContext(IConfiguration configuration,IHttpContextAccessor httpContext) 
        : base(httpContext) 
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString(nameof(FeiraMissionariaSqlServerDbContext)), options =>
                {
                    options.EnableRetryOnFailure();
                });
        }

        base.OnConfiguring(optionsBuilder);
    }
}
