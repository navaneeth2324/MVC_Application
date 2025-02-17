using Microsoft.EntityFrameworkCore;
using MVC_Application.Models;

namespace MVC_Application.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey(ic => new { ic.ItemId, ic.ClientId });
            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i=>i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c => c.ClientId);
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 5, Name = "Samsung Fold", Price = 52000, SerialNumberId = 10 }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { id = 10, Name = "SMGF", ItemId = 5 }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "5G" },
                new Category { Id = 2, Name = "4G" }
            );
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}
