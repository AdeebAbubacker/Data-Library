using DataLibrary_Api.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary_Api.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }

        public DbSet<GymEquipments> Gym { get; set; }
    }
}


