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
            modelBuilder.Entity<Campanha>().Navigation(p => p.CampanhaMidias).AutoInclude();

            modelBuilder.Entity<Midia>().HasQueryFilter(m => m.Excluida != true);


            modelBuilder.Entity<RelatorioSenha>().HasKey(r => new { r.IdPlayer, r.Numero, r.DataChamou });

            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne<Player>()
                      .WithMany()
                      .HasForeignKey(e => e.PlayerId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Campanha>()
                      .WithMany()
                      .HasForeignKey(e => e.CampanhaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Midia> Midias { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<CampanhaMidia> CampanhaMidias { get; set; }public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Agendamento> AgendamentoCampanhas { get; set; }
        public DbSet<Descricaocampanha> Descricaocampanhas { get; set; }
        public DbSet<Descricaomidia> Descricaomidias { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<RelatorioSenha> RelatorioSenhas { get; set; }
        public DbSet<TipoClima> TipoClimas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
