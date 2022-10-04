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
    }
}
