using Blogify.Domain.Data;
using Blogify.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Configuration;

public class ServicesConfiguration
{
    public static void ConfigureServices(ref WebApplicationBuilder app)
    {
        var connectionString = app.Configuration.GetConnectionString("BlogDb");
        app.Services.AddDbContext<BlogDbContext>(options =>
            options.UseNpgsql(connectionString));

        app.Services.AddScoped<IPostsRepository, PostsRepository>();
        app.Services.AddScoped<IUsersRepository, IUsersRepository>();
    }
}