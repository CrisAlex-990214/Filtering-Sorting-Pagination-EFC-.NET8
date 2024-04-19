using Microsoft.EntityFrameworkCore;

namespace Filters
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions opts) : base(opts)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Cookie Chocolate Chip With", Price = 24 },
            new Product { Id = 2, Name = "Wiberg Super Cure", Price = 16 },
            new Product { Id = 3, Name = "Temperature Recording Station", Price = 2 },
            new Product { Id = 4, Name = "Scallops - 10/20", Price = 45 },
            new Product { Id = 5, Name = "Cape Capensis - Fillet", Price = 34 },
            new Product { Id = 6, Name = "Veal - Striploin", Price = 42 },
            new Product { Id = 7, Name = "Celery", Price = 14 },
            new Product { Id = 8, Name = "Tart Shells - Savory, 4", Price = 11 },
            new Product { Id = 9, Name = "Pasta - Fusili Tri - Coloured", Price = 9 },
            new Product { Id = 10, Name = "Wine - Hardys Bankside Shiraz", Price = 90 }
            );

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Emily" });

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, UserId = 1 },
                new Order { Id = 2, UserId = 1 }
                );

            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Quantity = 3, ProductId = 2, OrderId = 1 },
                new Item { Id = 2, Quantity = 2, ProductId = 7, OrderId = 2 },
                new Item { Id = 3, Quantity = 1, ProductId = 6, OrderId = 2 }
                );
        }
    }
}
