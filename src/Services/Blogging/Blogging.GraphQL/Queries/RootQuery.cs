using Blogify.GraphQL.Queries.Posts;

namespace Blogify.GraphQL.Queries;

public class RootQuery
{
    public PostQuery PostQuery => new PostQuery();
}