using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Api.Extensions;

public static class WebApplicationExtensions
{
    public static void MigrateDatabase<TContext>(this WebApplication webApplication, 
        Action<TContext, IServiceProvider> seeder, int? retry = 0) 
            where TContext : DbContext
    {
        var retryForAvailability = retry ?? 0;
        using var scope = webApplication.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TContext>>();
        var context = services.GetRequiredService<TContext>();

        try
        {
            logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

            InvokeSeeder(seeder, context, services);

            logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
        }
        catch (SqlException ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);

            if (retryForAvailability < 50)
            {
                retryForAvailability++;
                Thread.Sleep(2000);
                webApplication.MigrateDatabase(seeder, retryForAvailability);
            }
        }
    }

    private static void InvokeSeeder<TContext>(
        Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
            where TContext : DbContext
    {
        context.Database.Migrate();
        seeder(context, services);
    }
}
