using Blogify.Domain.AggregationModels.Post;
using Blogify.Domain.Entities;

namespace Blogify.Persistence.Repositories;

public interface IPostsRepository: IBasicRepository<Post, Guid>
{
}