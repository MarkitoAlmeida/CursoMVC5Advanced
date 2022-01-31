﻿using System;
using System.Threading.Tasks;

namespace CsIO.Business.Models.Produtos.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
