using CsIO.Business.Models.Produtos;
using CsIO.Business.Models.Produtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsIO.Infra.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public async Task<Produto> ObterProdutosFornecedor(Guid id)
        {
            return await csIOContext.Produtos
                                        .AsNoTracking()
                                        .Include(f => f.Fornecedor)
                                        .FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await csIOContext.Produtos
                                        .AsNoTracking()
                                        .Include(f => f.Fornecedor)
                                        .OrderBy(p => p.Nome)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId.Equals(fornecedorId));
        }
    }
}
