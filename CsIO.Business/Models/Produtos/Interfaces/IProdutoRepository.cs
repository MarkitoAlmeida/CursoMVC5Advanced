using CsIO.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsIO.Business.Models.Produtos.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutosFornecedor();
    }
}
