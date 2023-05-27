using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;
using SistemasWeb01.ViewModels;

namespace SistemasWeb01.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly InterfazProducto _productoRepository;
        private readonly InterfazCategoria _categoriaRepository;
        public CategoriaController(InterfazProducto productoRepository, InterfazCategoria categoriaRepository)
        {
            _productoRepository = productoRepository;
            _categoriaRepository = categoriaRepository;
        }
        public IActionResult Index()
        {
            return View(_categoriaRepository.AllCategorias);
        }
        
        public IActionResult CreateCategoria()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.CreateCategoria(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);

        }
        public IActionResult CategoriaCreated()
        {
            ViewBag.CategoriaCreatedMessage = "CATEGORIA CREADA CORRECTAMENTE";
            return View();
        }
        public IActionResult UpdateCategoria(int id)
        {
            Categoria cat = _categoriaRepository.GetcatById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateCategoria(Categoria _categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.UpdateCategoria(_categoria);
                return RedirectToAction("Index", "Categoria");
            }
            else
            {
                return View(_categoria);
            }
        }

        public IActionResult detalleCategoria(int id)
        {
            Categoria cat = _categoriaRepository.GetcatById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult detalleCategoria(Categoria _categoria)
        {

            return View();

        }
        public IActionResult DeleteCategoria(int id)
        {
            Categoria cat = _categoriaRepository.GetcatById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }
        [HttpPost, ActionName("DeleteCategoria")]
        public IActionResult DeleteCategoria(Categoria _categoria)
        {
            Categoria cat = _categoriaRepository.GetcatById(_categoria.CategoriaId);

            _categoriaRepository.DeleteCategoria(cat);
            return RedirectToAction("Index", "Categoria");


        }
    }
}
