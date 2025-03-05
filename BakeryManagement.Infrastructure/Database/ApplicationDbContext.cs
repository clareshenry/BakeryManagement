using BakeryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakeryManagement.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BakeryOffice> BakeryOffices { get; set; }

        // public DbSet<Order> Orders { get; set; }
        // public DbSet<OrderItem> OrderItems { get; set; }
        // public DbSet<Bread> Breads { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BakeryOffice>(builder =>
            {
                builder.HasKey(bakeryOffice => bakeryOffice.Id);
                builder
                    .Property(bakeryOffice => bakeryOffice.Name)
                    .HasColumnName("name")
                    .IsRequired();
                builder
                    .Property(bakeryOffice => bakeryOffice.Capacity)
                    .HasColumnName("capacity")
                    .IsRequired();
            });
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //
        //     // Configure Bread entity inheritance mapping
        //     modelBuilder.Entity<Bread>().UseTphMappingStrategy();
        // }
    }
}
