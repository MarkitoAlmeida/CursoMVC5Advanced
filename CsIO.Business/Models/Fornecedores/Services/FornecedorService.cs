using CsIO.Business.Core.Services;
using CsIO.Business.Models.Fornecedores.Interfaces.Repositories;
using CsIO.Business.Models.Fornecedores.Interfaces.Services;
using CsIO.Business.Models.Fornecedores.Validations;
using CsIO.Business.Notifications;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CsIO.Business.Models.Fornecedores.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotification notification) : base(notification)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            // Limitações do EF 6 fora da convenção
            fornecedor.Endereco.Id = fornecedor.Id;
            fornecedor.Endereco.Fornecedor = fornecedor;

            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco))
                return;

            if (await FornecedorExiste(fornecedor))
                return;

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco))
                return;

            if (await FornecedorExiste(fornecedor))
            {
                Notificar("O Fornecedor possui produtos cadastrados.");
                return;
            }   

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            if (fornecedor.Produtos.Any())
            {
                Notificar("O Fornecedor possui produtos cadastrados.");
                return;
            }

            if (fornecedor.Endereco != null)
                await _enderecoRepository.Remover(fornecedor.Endereco.Id);

            await _fornecedorRepository.Remover(id);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco))
                return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> FornecedorExiste(Fornecedor fornecedor)
        {
            var fornecedorAtual = await _fornecedorRepository
                                            .Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id);

            if (fornecedorAtual.Any())
                return false;

            Notificar("Já existe um fornecedor com este documento.");

            return true;
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
