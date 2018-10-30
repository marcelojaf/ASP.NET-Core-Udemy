using AppVendas.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppVendas.Domain.Produto
{
    public class CategoriaStorer
    {
        private readonly IRepository<Categoria> _categoriaRepository;

        public CategoriaStorer(IRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Store(CategoriaDto dto)
        {
            var categoria = _categoriaRepository.GetById(dto.Id);

            if (categoria == null)
            {
                categoria = new Categoria(dto.Nome);
                _categoriaRepository.Save(categoria);
            }
            else
            {
                categoria.Atualizar(dto.Nome);
            }
        }
    }
}
