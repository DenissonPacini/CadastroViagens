using CadastroViagens.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroViagens.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Viagem> Viagem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Motorista>()
                .HasOne(p => p.Caminhao)
                .WithOne(p => p.Motorista)
                .HasForeignKey<Caminhao>(m => m.IdMotorista);

            modelBuilder.Entity<Motorista>()
                .HasOne(p => p.Viagem)
                .WithOne(p => p.Motorista)
                .HasForeignKey<Viagem>(p => p.IdMotorista);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
