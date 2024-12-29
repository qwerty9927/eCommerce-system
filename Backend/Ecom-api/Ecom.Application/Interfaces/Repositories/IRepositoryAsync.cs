namespace Ecom.Application.Interfaces.Repositories
{
    public interface IRepositoryAsync<T>
    {
        public Task<IList<T>> GetAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task<bool> CreateAsync(T entity);
        public Task<bool> DeleteAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
    }
}
