using Clobo.Application.Common.Interfaces;
using Clobo.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //TODO: Add SQL Server and SQL Lite
        //TODO: Add JWT and auth here
        //TODO: This is where all the one time checks happen for database provider.

        services.AddDbContext<CloboContext>(options =>
            options.UseSqlite("FileName=Clobo.db"
                , x => x.MigrationsAssembly("Clobo.Infrastructure")));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<CloboContext>());
        services.AddScoped<DatabaseContextInitializer>();

        return services;
    }
}