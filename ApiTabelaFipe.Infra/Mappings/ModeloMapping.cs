using ApiTabelaFipe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTabelaFipe.Infra.Mappings
{
    public class ModeloMapping : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("MODELO");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("DESCRICAO");

            builder.Property(x => x.MarcaCodigo)
                .HasColumnName("MARCA_CODIGO");

            builder.HasOne(x => x.Marca)
               .WithMany(x => x.Modelos)
               .HasForeignKey(x => x.MarcaCodigo)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
