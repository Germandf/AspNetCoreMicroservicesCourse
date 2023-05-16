using AspnetRunBasics.Data;

public static class WebApplicationExtensions
{
    public static void SeedDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

        try
        {
            var aspnetRunContext = app.Services.GetRequiredService<AspnetRunContext>();
            AspnetRunContextSeed.SeedAsync(aspnetRunContext, loggerFactory).Wait();
        }
        catch (Exception exception)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(exception, "An error occurred seeding the DB.");
        }
    }
}
