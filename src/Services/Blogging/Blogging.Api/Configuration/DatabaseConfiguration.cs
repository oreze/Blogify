using Blogify.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Configuration;

public class DatabaseExtensions
{
    public static void ConfigureDatabase(WebApplication app)
    {
        ApplyMigrations(app);
    }

    private static void ApplyMigrations(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<IDbContextFactory<BlogDbContext>>().CreateDbContext();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}