namespace Blogify.Persistence.Repositories;

public interface IBasicRepository<TEntity, TId> 
    where TEntity: class
    where TId: struct, IFormattable
{
    public IEnumerable<TEntity> GetAll(int page, int offset);
    public TEntity GetById(TId id);
    public void Insert(TEntity entity);
    public void Delete(TId id);
    
    public Task<IEnumerable<TEntity>> GetAllAsync(int page, int offset);
    public Task<TEntity> GetByIdAsync(TId id);
    public Task InsertAsync(TEntity entity);
    public Task DeleteAsync(TId id);
}