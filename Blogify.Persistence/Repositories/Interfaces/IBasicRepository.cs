namespace Blogify.Persistence.Repositories;

public interface IBasicRepository<T> where T: class
{
    public IEnumerable<T> GetAll(int page, int offset);
    public T GetById(long id);
    public void Insert(T entity);
    public void Update(T entity);
    public void Delete(long id);
    public void Save();
}