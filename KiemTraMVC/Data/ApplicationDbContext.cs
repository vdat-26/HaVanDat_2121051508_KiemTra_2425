using Microsoft.EntityFrameworkCore;
using KiemTraMVC.Models;

namespace KiemTraMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<HaVanDat> HaVanDat { get; set; }
    }
}
