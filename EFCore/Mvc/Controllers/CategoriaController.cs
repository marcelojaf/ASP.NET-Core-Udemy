using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult Editar(int id)
        {
            var categoria = _context.Categorias.First(c => c.Id == id);
            return View("Salvar", categoria);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var categoria = _context.Categorias.First(c => c.Id == id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Salvar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Categoria categoria)
        {
            if (categoria.Id == 0)  _context.Categorias.Add(categoria);
            else {
                var cat = _context.Categorias.First(c => c.Id == categoria.Id);
                cat.Nome = categoria.Nome;
                cat.PermiteEstoque = categoria.PermiteEstoque;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}