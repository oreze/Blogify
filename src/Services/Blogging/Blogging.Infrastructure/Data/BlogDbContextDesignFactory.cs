using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Blogify.Domain.Data;

public class BlogDbContextDesignFactory: IDesignTimeDbContextFactory<BlogDbContext>
{
    public BlogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>()
            .UseNpgsql("Host=localhost;Port=5438;Database=postgres;Username=postgres;Password=postgres");
        return new BlogDbContext(optionsBuilder.Options);
    }
    
}
