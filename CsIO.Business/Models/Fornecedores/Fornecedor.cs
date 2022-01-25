using CsIO.Business.Core.Models;
using CsIO.Business.Models.Fornecedores.Enums;
using CsIO.Business.Models.Produtos;
using System.Collections.Generic;

namespace CsIO.Business.Models.Fornecedores
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public ETipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* ER Relations */
        public ICollection<Produto> Produtos { get; set; }
    }
}
