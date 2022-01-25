using CsIO.Business.Models.Fornecedores;
using System.Data.Entity.ModelConfiguration;

namespace CsIO.Infra.Data.Mappings
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Enderecos");
            HasKey(e => e.Id);

            Property(e => e.Rua)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Complemento)
                .HasMaxLength(200);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
