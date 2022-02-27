using Blogify.Domain.AggregationModels.Post;
using Blogify.Domain.Entities;
using Blogify.Persistence.Repositories;

namespace Blogify.GraphQL.Resolvers.Posts;

public class PostsResolver
{
    
    public async Task<User> GetAuthor([Service] IUsersRepository usersRepository, long id)
    {
        return await usersRepository.GetByIdAsync(id);
    }
}