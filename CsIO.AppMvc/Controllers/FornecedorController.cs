using CsIO.Business.Models.Fornecedores;
using CsIO.Business.Models.Fornecedores.Enums;
using CsIO.Business.Models.Fornecedores.Interfaces.Services;
using CsIO.Business.Models.Fornecedores.Services;
using CsIO.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CsIO.AppMvc.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _fornecedorService;

        // Construtor sem Injeção de Dependência => A ser implementado a ID
        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        // GET: Fornecedor
        public async Task<ActionResult> Index()
        {
            var fornecedor = new Fornecedor()
            {
                Nome = "Marcos",
                Documento = "06655717981",
                Endereco = new Endereco()
                {
                    Rua = "Camilo Castelo Branco",
                    Numero = "838",
                    Complemento = "9C",
                    Bairro = "Santa Marinha",
                    Cep = "4400-060",
                    Cidade = "Porto",
                    Estado = "Porto"
                },
                TipoFornecedor = ETipoFornecedor.PessoaFisica,
                Ativo = true
            };

            await _fornecedorService.Adicionar(fornecedor);

            return new EmptyResult();
        }
    }
}