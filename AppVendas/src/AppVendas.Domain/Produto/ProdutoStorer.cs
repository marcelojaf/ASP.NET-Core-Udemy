using AppVendas.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVendas.Domain.Produto
{
    public class ProdutoStorer
    {
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public ProdutoStorer(IRepository<Produto> produtoRepository, IRepository<Categoria> categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }
        public void Store(ProdutoDto dto)
        {
            var categoria = _categoriaRepository.GetById(dto.CategoriaId);
            DomainException.When(categoria == null, "Categoria inválida.");

            var produto = _produtoRepository.GetById(dto.Id);
            if (produto == null)
            {
                produto = new Produto(dto.Nome, categoria, dto.Preco, dto.QuantidadeEmEstoque);
                _produtoRepository.Save(produto);
            }
            else
            {
                produto.Atualizar(dto.Nome, categoria, dto.Preco, dto.QuantidadeEmEstoque);
            }
        }
    }
}
