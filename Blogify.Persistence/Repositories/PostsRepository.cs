using Blogify.Domain.Data;

namespace Blogify.Persistence.Repositories;

public class PostsRepository
{
    private readonly BlogDbContext _context;

    public PostsRepository(BlogDbContext context)
    {
        _context = context;
    }
}