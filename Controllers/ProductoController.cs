using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;
using SistemasWeb01.ViewModels;
using static SistemasWeb01.Models.InterfazCategoria;

namespace SistemasWeb01.Controllers
{
    public class ProductoController : Controller
    {
        private readonly InterfazProducto _RepositorioProducto;
        private readonly InterfazCategoria _RepositorioCategoria;
        public ProductoController(InterfazProducto RepositorioProducto, InterfazCategoria RepositorioCategoria)
        {
            _RepositorioProducto = RepositorioProducto;
            _RepositorioCategoria = RepositorioCategoria;
        }
        public IActionResult Detalles(int id)
        {
            var producto = _RepositorioProducto.GetcatById(id);
            if (producto == null)
                return NotFound();
            return View(producto);
        }
        public IActionResult Mensajepro()
        {
            Producto produc = new Producto();
            ProductoListViewModel list = new ProductoListViewModel(_RepositorioCategoria.Categorias, _RepositorioProducto.productosList, produc);
            //IEnumerable<producto> productos1 = _productoRepository.productosList;
            //IEnumerable<categoria> categorias = _categoryRepository.Categorias;
            return View(list);
        }
        public IActionResult Index()
        {
            return View(_RepositorioProducto.filtroDelete);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            Producto varProducto = new Producto();
            ProductoListViewModel models = new ProductoListViewModel(_RepositorioCategoria.Categorias, _RepositorioProducto.productosList, varProducto);
            //IEnumerable<producto> productos1 = _productoRepository.productosList;
            //IEnumerable<categoria> categorias = _categoryRepository.Categorias;
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ProductoListViewModel producto, IFormFile imagen)
        {

            if (imagen != null && imagen.Length > 0)
            {
                var fileName = Path.GetFileName(imagen.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }

                producto.productoClass.ImagenProducto = fileName; // Guardamos el nombre de la imagen en el atributo imagen del modelo Producto
            }

            _RepositorioProducto.agregar(producto.productoClass);
            return RedirectToAction("Index");


            return View(producto);
        }
        public IActionResult UpdateProducto(int id)
        {
            Producto cat = _RepositorioProducto.GetcatById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _RepositorioProducto.Update(producto);
                return RedirectToAction("Index", "Producto");
            }
            else
            {
                return View(producto);
            }
        }

        //public IActionResult detalleCategoria(int id)
        //{
        //    Categoria cat = _categoriaRepository.GetcatById(id);
        //    if (cat != null)
        //    {
        //        return View(cat);
        //    }

        //    return NotFound();
        //}
        //[HttpPost]
        //public IActionResult detalleCategoria(Categoria _categoria)
        //{

        //    return View();

        //}
        public IActionResult DeleteProducto(int id)
        {

            Producto cat = _RepositorioProducto.GetcatById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }
        [HttpPost, ActionName("DeleteProducto")]
        public IActionResult DeleteProducto(Producto producto)
        {
            Producto cat = _RepositorioProducto.GetcatById(producto.ProductoId);

            _RepositorioProducto.Delete(cat);
            return RedirectToAction("Index", "Producto");


        }
        public IActionResult Deletet(int id)
        {
            Producto prod = _RepositorioProducto.GetcatById(id);
            if (prod != null)
            {
                return View(prod);
            }

            return NotFound();
        }
        //método de acción HTTP POST llamado "Deletet" que maneja la eliminación de un producto en una aplicación web.
        [HttpPost, ActionName("Deletet")]
        public IActionResult Deletet(Producto producto)
        {
            Producto prod = _RepositorioProducto.GetcatById(producto.ProductoId);
            prod.Deleted = false;
            _RepositorioProducto.Deletet(prod);
            return RedirectToAction("Index", "producto");
        }
    }
}
