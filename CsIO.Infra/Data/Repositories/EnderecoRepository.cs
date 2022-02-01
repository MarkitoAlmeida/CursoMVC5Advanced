using CsIO.Business.Models.Fornecedores;
using CsIO.Business.Models.Fornecedores.Interfaces.Repositories;
using CsIO.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace CsIO.Infra.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CsIoContext context) : base(context)  { }

        public async Task<Endereco> ObterEnderecoPorFonecedor(Guid fornecedorId)
        {
            return await ObterPorId(fornecedorId);
        }
    }
}
 