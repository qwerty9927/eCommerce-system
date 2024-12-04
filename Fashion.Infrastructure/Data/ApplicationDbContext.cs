using Fashion.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<PaymentProfile> PaymentProfiles { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<DeliveryInformation> DeliveryInformations { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // builder.Entity<Product>()
        //     .HasOne(p => p.Category)
        //     .WithMany(c => c.Products)
        //     .HasForeignKey(p => p.CategoryId);

        // builder.Entity<Category>()
        //     .HasMany(c => c.Products)
        //     .WithOne(p => p.Category);
    }
}
