using CsIO.Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace CsIO.Business.Models.Fornecedores.Interfaces.Repositories
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
