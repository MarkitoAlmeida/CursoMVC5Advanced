using CsIO.Business.Models.Fornecedores;
using CsIO.Business.Models.Fornecedores.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace CsIO.Infra.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public async Task<Endereco> ObterEnderecoPorFonecedor(Guid fornecedorId)
        {
            return await ObterPorId(fornecedorId);
        }
    }
}
 