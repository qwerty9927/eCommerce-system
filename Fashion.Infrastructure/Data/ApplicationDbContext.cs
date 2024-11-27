using Fashion.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
