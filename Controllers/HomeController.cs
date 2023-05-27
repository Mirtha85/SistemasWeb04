using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SistemasWeb01.Models;
using SistemasWeb01.ViewModels;

namespace SistemasWeb01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private readonly InterfazProducto _RepositorioProducto;
        private readonly InterfazCategoria _RepositorioCategoria;
        public HomeController(InterfazProducto RepositorioProducto, InterfazCategoria RepositorioCategoria)
        {
            _RepositorioProducto = RepositorioProducto;
            _RepositorioCategoria = RepositorioCategoria;
        }
        public IActionResult Index()
        {
            Producto produc = new Producto();
            ProductoListViewModel list = new ProductoListViewModel(_RepositorioCategoria.Categorias, _RepositorioProducto.productosList, produc);
            //IEnumerable<producto> productos1 = _productoRepository.productosList;
            //IEnumerable<categoria> categorias = _categoryRepository.Categorias;
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}