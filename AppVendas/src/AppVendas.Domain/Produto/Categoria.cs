using System;
using System.Collections.Generic;
using System.Text;

namespace AppVendas.Domain.Produto
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; private set; }

        public Categoria(string nome)
        {
            ValidarESetarPropriedades(nome);
        }

        public void Atualizar(string nome)
        {
            ValidarESetarPropriedades(nome);
        }

        private void ValidarESetarPropriedades(string nome)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Nome é obrigatório.");

            Nome = nome;
        }
    }
}
