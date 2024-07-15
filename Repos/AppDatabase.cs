using GestorMegaTv.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorMegaTv.Repos
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {

        }
        public DbSet<Player> Players { get; set; }


    }
}
