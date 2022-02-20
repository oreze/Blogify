using Blogify.Domain.AggregationModels.Post;
using Blogify.Domain.Entities;
using Blogify.GraphQL.Resolvers.Posts;
using Blogify.Persistence.Repositories;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Builder;

namespace Blogify.GraphQL.Groups.Posts;

public class PostType: ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor
            .Field(f => f.Author)
            .ResolveWith<Resolvers>(r => r.GetAuthor(default!, default!));
    }

    private class Resolvers
    {
        public async Task<User> GetAuthor([Parent] Post post, [Service] IUsersRepository usersRepository)
        {
            return await usersRepository.GetByIdAsync(post.AuthorId);
        }
    }
}