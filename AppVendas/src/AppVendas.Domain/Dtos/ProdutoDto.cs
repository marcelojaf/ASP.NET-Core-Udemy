using System;
using System.Collections.Generic;
using System.Text;

namespace AppVendas.Domain.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int CategoriaId { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
    }
}
