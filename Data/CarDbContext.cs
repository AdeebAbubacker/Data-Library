using DataLibrary_Api.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary_Api.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

        public DbSet<Cars> Cars { get; set; }
    }
}


