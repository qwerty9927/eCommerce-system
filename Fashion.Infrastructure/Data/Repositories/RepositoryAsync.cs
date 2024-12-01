using Fashion.Infrastructure.Data;
using Fashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Services.repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public DbSet<T> Table { get; set; }

        public RepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            Table = _context.Set<T>();
        }

        public async Task<IList<T>> GetAsync()
        {
            return await Table.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            if (entity == null) return false;

            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null) return false;

            Table.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null) return false;

            Table.Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
