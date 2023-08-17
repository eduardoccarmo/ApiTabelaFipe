using ApiTabelaFipe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTabelaFipe.Infra.Mappings
{
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("MARCA");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("DESCRICAO")
                .HasColumnType("VARCHAR2")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany(x => x.Modelos)
                .WithOne(x => x.Marca)
                .HasForeignKey(x => x.MarcaCodigo);
        }
    }
}
