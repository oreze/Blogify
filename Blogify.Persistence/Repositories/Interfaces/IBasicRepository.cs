namespace Blogify.Persistence.Repositories;

public interface IBasicRepository<T> where T: class
{
    public IEnumerable<T> GetAll(int page, int offset);
    public T GetById(Guid id);
    public void Insert(T entity);
    public void Update(T entity);
    public void Delete(Guid id);
    
    public Task<IEnumerable<T>> GetAllAsync(int page, int offset);
    public Task<T> GetByIdAsync(Guid id);
    public Task InsertAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(Guid id);
}