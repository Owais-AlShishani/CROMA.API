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


            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                DateFrom = new DateTime(2022, 10, 09),
                DateTo = new DateTime(2022, 10, 20),
                UserName = "Owais",
                PhoneNumber = 962776968787,
                Comment = "Nice Car",
                CarId = 1,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 2,
                DateFrom = new DateTime(2022, 10, 10),
                DateTo = new DateTime(2022, 10, 30),
                UserName = "Omar",
                PhoneNumber = 962779654107,
                Comment = "No Comment",
                CarId = 2,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 3,
                DateFrom = new DateTime(2022, 10, 01),
                DateTo = new DateTime(2022, 12, 20),
                UserName = "Ali",
                PhoneNumber = 96277050507,
                Comment = "No Comment",
                CarId = 3,
            });
        }
    }
}
