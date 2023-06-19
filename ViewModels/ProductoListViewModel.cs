using SistemasWeb01.Models;

namespace SistemasWeb01.ViewModels
{
    public class ProductoListViewModel
    {
        public IEnumerable<Producto> Productos { get; }
        public IEnumerable<Categoria> categorias { get; }

        public Producto ProductoId { get; set; }
        public Producto productoClass { get; set; }

        public ProductoListViewModel(IEnumerable<Categoria> _categoria, IEnumerable<Producto> _producto, Producto _productoClass)
        {
            categorias = _categoria;
            Productos = _producto;
            productoClass = _productoClass;
        }

        public ProductoListViewModel() { }
    }
}
