using Blogify.Domain.AggregationModels.Post;
using Blogify.Domain.Data;
using Blogify.GraphQL.Configuration;
using Blogify.GraphQL.Groups.Posts;
using Blogify.GraphQL.Queries;
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

        app.Services
            .AddGraphQLServer()
            .AddQueryType<RootQuery>()
            .AddType<PostType>();
            
        app.Services.AddErrorFilter<GraphQLErrorFilter>();

        app.Services.AddScoped<IPostsRepository, PostsRepository>();
        app.Services.AddScoped<IUsersRepository, UsersRepository>();
    }
}