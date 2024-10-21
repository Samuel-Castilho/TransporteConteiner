using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Transporte.Persistencia.TypeConfiguration
{
    public class ConteinerTypeConfiguration : IEntityTypeConfiguration<Conteiner>
    {
        public void Configure(EntityTypeBuilder<Conteiner> builder)
        {
            builder.HasKey(x => x.Numero);

        }





    }
}
