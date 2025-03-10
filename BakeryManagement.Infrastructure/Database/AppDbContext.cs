using BakeryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakeryManagement.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Bread> Breads { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<BakeryOffice> BakeryOffices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=bakery_db;Username=eras_user;Password=eras_password"
            );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
