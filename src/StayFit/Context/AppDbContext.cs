using Microsoft.EntityFrameworkCore;
using StayFit.Models;

namespace StayFit.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Ficha> Ficha { get; set; }
        public DbSet<Instrutor> Instrutores { get; set; }

         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Instrutor>().HasData(
                new Instrutor
                {
                    InstrutorId = 1,
                    Nome = "Paulo",
                    Telefone = "93333-5555",
                    Email = "Paulo@eu.com",                   
                    
                }               
              );

           modelBuilder.Entity<Cliente>()
          .Property(c => c.Matricula)
          .HasComputedColumnSql("CAST(ClienteId + 120 * 1000 AS INT)");

        }
    }
}
