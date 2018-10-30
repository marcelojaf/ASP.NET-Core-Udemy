using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVendas.Web.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateOrEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrEdit(int id)
        {
            return View();
        }
    }
}
