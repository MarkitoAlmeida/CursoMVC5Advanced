using CsIO.Business.Models.Produtos;
using System.Data.Entity.ModelConfiguration;

namespace CsIO.Infra.Data.Mappings
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produtos");
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            Property(p => p.Imagem)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(p => p.Fornecedor)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.FornecedorId);
        }
    }
}
