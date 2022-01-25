using CsIO.Business.Models.Fornecedores;
using CsIO.Business.Models.Produtos;
using CsIO.Infra.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CsIO.Infra.Data.Context
{
    public class CsIoContext : DbContext
    {
        public CsIoContext() : base("DefaultConnection") 
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar")
                                 .HasMaxLength(100));

            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
