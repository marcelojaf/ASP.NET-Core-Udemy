using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var produtos = _context.Produtos
                .Where(p => p.Ativo && p.Categoria.PermiteEstoque)
                .OrderBy(p => p.Nome);

            if (!produtos.Any())
            {
                return View(new List<Produto>());
            }

            return View(produtos.ToList());
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            var produto = _context.Produtos.First(c => c.Id == id);
            return View("Salvar", produto);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var categoria = _context.Produtos.First(c => c.Id == id);
            _context.Produtos.Remove(categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Produto produto)
        {
            if (produto.Id == 0) _context.Produtos.Add(produto);
            else
            {
                var prod = _context.Produtos.First(c => c.Id == produto.Id);
                prod.Nome = produto.Nome;
                prod.CategoriaId = produto.CategoriaId;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}