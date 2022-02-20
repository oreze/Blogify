using Blogify.Domain.AggregationModels.Post;
using Blogify.Domain.Data;
using Blogify.GraphQL.Inputs;
using Blogify.Persistence.Repositories;

namespace Blogify.GraphQL.Queries.Posts;

public class PostQuery
{
    public async Task<IEnumerable<Post>> GetPosts([Service] IPostsRepository postsRepository, PaginationInput input) =>
        await postsRepository.GetAllAsync(input.Page, input.PageSize);
}