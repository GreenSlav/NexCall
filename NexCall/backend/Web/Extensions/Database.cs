using Core.Abstractions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Web.Extensions;

public static class Database
{
    public static void RegisterPostgresDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbContext, EfContext>();
        services.AddDbContext<EfContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}