using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Transporte.Persistencia.TypeConfiguration
{
    public class MovimentacaoTypeConfiguration : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<Conteiner>()
                .WithMany()
                .HasForeignKey(x => x.NumeroConteiner)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        }
    }
}
