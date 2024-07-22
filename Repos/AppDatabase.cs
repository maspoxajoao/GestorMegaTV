using GestorMegaTv.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorMegaTv.Repos
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Midia>().HasQueryFilter(m => m.Excluida != true);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Midia> Midias { get; set; }


    }
}
