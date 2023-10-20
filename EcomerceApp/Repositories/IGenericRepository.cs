namespace EconomicApp.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T model);
        Task<T?> UpdateAsync(Guid id, T model);
        Task<T?> DeleteAsync(Guid id);
    }
}
