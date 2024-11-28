using Fashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<DeliveryInformation> DeliveryInformations { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
