using CsIO.Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace CsIO.Business.Models.Fornecedores.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFonecedor(Guid fornecedorId);
    }
}
