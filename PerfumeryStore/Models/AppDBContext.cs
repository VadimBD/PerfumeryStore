using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace PerfumeryStore.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Paymant> Paymants { get; set; }
        public DbSet<ProductСontainer> ProductСontainers { get; set; }
        public DbSet<CartLine> CartLines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Review>().Property(r => r.IsertedDate).HasDefaultValueSql("GETDATE()");
            builder.Entity<Order>().Property(o => o.OrderDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
