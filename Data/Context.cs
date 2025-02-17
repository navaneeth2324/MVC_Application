using Microsoft.EntityFrameworkCore;
using MVC_Application.Models;

namespace MVC_Application.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 5, Name = "Samsung Fold", Price = 52000, SerialNumberId = 10 }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { id = 10, Name = "SMGF", ItemId = 5 }
            );
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
    }
}
