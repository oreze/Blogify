using System.Linq;
using Blogify.Domain.Data;
using Blogify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Persistence.Repositories;

public class UsersRepository: IUsersRepository
{
    private readonly IDbContextFactory<BlogDbContext> _contextFactory;

    public UsersRepository(IDbContextFactory<BlogDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IEnumerable<User> GetAll(int page, int pageSize)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Users
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public User GetById(long id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Users.FirstOrDefault(post => post.Id == id);
    }

    public void Insert(User entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Add(entity);
        context.SaveChanges();
    }

    public void Delete(long id)
    {
        using var context = _contextFactory.CreateDbContext();
        var foundItem = context.Users.FirstOrDefault(post => post.Id == id);
        if (foundItem != null)
        {
            context.Users.Remove(foundItem);
            context.SaveChanges();
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync(int page, int pageSize)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Users
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<User> GetByIdAsync(long id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Users.FirstOrDefaultAsync(post => post.Id == id);   
    }

    public async Task InsertAsync(User entity)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        await context.AddAsync(entity);
        await context.SaveChangesAsync();    
    }

    public async Task DeleteAsync(long id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var foundItem = await context.Users.FirstOrDefaultAsync(post => post.Id == id);
        if (foundItem != null)
        {
            context.Users.Remove(foundItem);
            await context.SaveChangesAsync();
        }
    }
}