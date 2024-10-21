using Microsoft.EntityFrameworkCore;
using Models;

namespace Transporte.Persistencia.Context
{
    public class TransporteContext : DbContext
    {

        public TransporteContext(DbContextOptions<TransporteContext> options):base(options)
        {
            
        }


        public DbSet<Conteiner> Conteiners { get; set; }
        public DbSet<Movimentacao> Movimentacaos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransporteContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
