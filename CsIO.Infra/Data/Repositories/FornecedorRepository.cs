using CsIO.Business.Models.Fornecedores;
using CsIO.Business.Models.Fornecedores.Interfaces.Repositories;
using CsIO.Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CsIO.Infra.Data.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CsIoContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await csIOContext.Fornecedores
                                        .AsNoTracking()
                                        .Include(f => f.Endereco)
                                        .FirstOrDefaultAsync(f => f.Id.Equals(id));
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await csIOContext.Fornecedores
                                        .AsNoTracking()
                                        .Include(f => f.Endereco)
                                        .Include(f => f.Produtos)
                                        .FirstOrDefaultAsync(f => f.Id.Equals(id));
        }
    }
}
