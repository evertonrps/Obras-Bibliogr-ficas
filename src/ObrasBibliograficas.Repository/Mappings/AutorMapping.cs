using ObrasBibliograficas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObrasBibliograficas.Repository.Extensions;

namespace ObrasBibliograficas.Repository.Mappings
{
    public class AutorMapping : EntityTypeConfiguration<Autor>
    {
        public override void Map(EntityTypeBuilder<Autor> builder)
        {
            builder.Property(c => c.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired(false);


            builder.Property(c => c.SobreNome)
               .HasColumnType("varchar(150)")
               .IsRequired(true);

            builder.ToTable("Autores");
        }
    }
}
