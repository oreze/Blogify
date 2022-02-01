using Blogify.Domain.Data;
using Blogify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Persistence.Repositories;

public class PostsRepository: IPostsRepository
{
    private readonly BlogDbContext _context;

    public PostsRepository(BlogDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Post> GetAll(int page, int pageSize)
    {
        return _context.Posts
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Post GetById(Guid id)
    {
        return _context.Posts.FirstOrDefault(post => post.Id == id);
    }

    public void Insert(Post entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }
    
    public void Delete(Guid id)
    {
        var foundItem = _context.Posts.FirstOrDefault(post => post.Id == id);
        if (foundItem != null)
        {
            _context.Posts.Remove(foundItem);
            _context.SaveChanges();
        }
    }

    public async Task<IEnumerable<Post>> GetAllAsync(int page, int pageSize)
    {
        return await _context.Posts
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Post> GetByIdAsync(Guid id)
    {
        return await _context.Posts.FirstOrDefaultAsync(post => post.Id == id);    
    }

    public async Task InsertAsync(Post entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();    
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var foundItem = await _context.Posts.FirstOrDefaultAsync(post => post.Id == id);
        if (foundItem != null)
        {
            _context.Posts.Remove(foundItem);
            await _context.SaveChangesAsync();
        }
    }
}