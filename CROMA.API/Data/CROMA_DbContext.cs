using CROMA.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CROMA.API.Data
{
    public class CROMA_DbContext : DbContext
    {
        public CROMA_DbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, CarType = "BMW" });
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 2, CarType = "KIA" });
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 3, CarType = "TOYOTA" });
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 4, CarType = "SUBARU" });
        }
    }
}
