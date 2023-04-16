using Microsoft.EntityFrameworkCore;
using StayFit.Models;

namespace StayFit.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 

      //  public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
      //  public DbSet<Ficha> Fichas { get; set; }
    }
}
