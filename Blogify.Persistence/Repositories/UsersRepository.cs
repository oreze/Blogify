using System.Linq;
using Blogify.Domain.Data;
using Blogify.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogify.Persistence.Repositories;

public class UsersRepository: IUsersRepository
{
    private readonly BlogDbContext _context;

    public UsersRepository(BlogDbContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll(int page, int pageSize)
    {
        return _context.Users
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public User GetById(long id)
    {
        return _context.Users.FirstOrDefault(post => post.Id == id);
    }

    public void Insert(User entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(long id)
    {
        var foundItem = _context.Users.FirstOrDefault(post => post.Id == id);
        if (foundItem != null)
        {
            _context.Users.Remove(foundItem);
            _context.SaveChanges();
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync(int page, int pageSize)
    {
        return await _context.Users
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<User> GetByIdAsync(long id)
    {
        return await _context.Users.FirstOrDefaultAsync(post => post.Id == id);   
    }

    public async Task InsertAsync(User entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();    
    }

    public async Task DeleteAsync(long id)
    {
        var foundItem = await _context.Users.FirstOrDefaultAsync(post => post.Id == id);
        if (foundItem != null)
        {
            _context.Users.Remove(foundItem);
            await _context.SaveChangesAsync();
        }
    }
}