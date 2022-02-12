using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Models;

namespace Smart_Cookers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
               }

        public DbSet<Role> Roles { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(p => p.Products)
                .WithMany(p => p.Orders)
                .UsingEntity<OrderProduct>(
                    j => j
                        .HasOne(pt => pt.Product)
                        .WithMany(t => t.OrderProducts)
                        .HasForeignKey(pt => pt.ProductId),
                    j => j
                        .HasOne(pt => pt.Order)
                        .WithMany(p => p.OrderProducts)
                        .HasForeignKey(pt => pt.OrderId),
                    j =>
                    {
                        j.Property(pt => pt.Quantity);
                        j.HasKey(t => new { t.OrderId, t.ProductId });
                    });

            modelBuilder.Entity<Outlet>()
               .HasMany(p => p.Products)
               .WithMany(p => p.Outlets)
               .UsingEntity<OutletProduct>(
                   j => j
                       .HasOne(pt => pt.Product)
                       .WithMany(t => t.OutletProducts)
                       .HasForeignKey(pt => pt.ProductId),
                   j => j
                       .HasOne(pt => pt.Outlet)
                       .WithMany(p => p.OutletProducts)
                       .HasForeignKey(pt => pt.OutletId),
                   j =>
                   {
                       j.Property(pt => pt.AvailableQuantity);
                       j.HasKey(t => new { t.OutletId, t.ProductId });
                   });
        }



    }
}

