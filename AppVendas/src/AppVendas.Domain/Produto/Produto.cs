using System;
using System.Collections.Generic;
using System.Text;

namespace AppVendas.Domain.Produto
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Categoria Categoria { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }

        public Produto(string nome, Categoria categoria, decimal preco, int quantidadeEmEstoque)
        {
            ValidarPropriedades(nome, categoria, preco, quantidadeEmEstoque);
            SetarPropriedades(nome, categoria, preco, quantidadeEmEstoque);
        }

        public void Atualizar(string nome, Categoria categoria, decimal preco, int quantidadeEmEstoque)
        {
            ValidarPropriedades(nome, categoria, preco, quantidadeEmEstoque);
            SetarPropriedades(nome, categoria, preco, quantidadeEmEstoque);
        }

        private static void ValidarPropriedades(string nome, Categoria categoria, decimal preco, int quantidadeEmEstoque)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Nome é obrigatório.");
            DomainException.When(categoria == null, "Categoria é obrigatório.");
            DomainException.When(preco < 0, "Preço deve ser maior que zero.");
            DomainException.When(quantidadeEmEstoque < 0, "Quantidade em estoque deve ser maior que zero.");
        }

        private void SetarPropriedades(string nome, Categoria categoria, decimal preco, int quantidadeEmEstoque)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }
    }
}
