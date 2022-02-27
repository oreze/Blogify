using Blogify.Domain.AggregationModels.Post;
using Blogify.Domain.Data;
using Blogify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Persistence.Repositories;

public class PostsRepository: IPostsRepository
{
    private readonly IDbContextFactory<BlogDbContext> _contextFactory;

    public PostsRepository(IDbContextFactory<BlogDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IEnumerable<Post> GetAll(int page, int pageSize)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Posts
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public Post GetById(Guid id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Posts.FirstOrDefault(post => post.Id == id);
    }

    public void Insert(Post entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Add(entity);
        context.SaveChanges();
    }
    
    public void Delete(Guid id)
    {
        using var context = _contextFactory.CreateDbContext();
        var foundItem = context.Posts.FirstOrDefault(post => post.Id == id);
        if (foundItem != null)
        {
            context.Posts.Remove(foundItem);
            context.SaveChanges();
        }
    }

    public async Task<IEnumerable<Post>> GetAllAsync(int page, int pageSize)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Posts
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Post> GetByIdAsync(Guid id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Posts.FirstOrDefaultAsync(post => post.Id == id);    
    }

    public async Task InsertAsync(Post entity)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        await context.AddAsync(entity);
        await context.SaveChangesAsync();    
    }
    
    public async Task DeleteAsync(Guid id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var foundItem = await context.Posts.FirstOrDefaultAsync(post => post.Id == id);
        if (foundItem != null)
        {
            context.Posts.Remove(foundItem);
            await context.SaveChangesAsync();
        }
    }
}