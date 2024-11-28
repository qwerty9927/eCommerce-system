using Fashion.Infrastructure.Data;
using Fashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Services.repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _dbSet = _context.Set<T>();
        }

        public async Task<IList<T>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            if (entity == null) return false;

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null) return false;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
