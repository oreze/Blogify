using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.Infrastructure.Data;

public class AppIdentityDbContextFactory: IDesignTimeDbContextFactory<AppIdentityDbContext>
{
    public AppIdentityDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>()
            .UseNpgsql("Host=identitydb;Port=5432;Database=postgres;Username=postgres;Password=postgres");
        return new AppIdentityDbContext(optionsBuilder.Options);
    }
}