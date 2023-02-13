namespace WebApiTask.Services
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task CreateAsync(T entity);

        Task DeleteAsync(int id);

        Task UpdateAsync(T entity);
    }
}
