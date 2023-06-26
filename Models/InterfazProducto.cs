using System.IO.Pipelines;

namespace SistemasWeb01.Models
{
    public interface InterfazProducto
    {
        public void agregar(Producto producto);
        public void UpdateProducto(Producto producto);
        public void Delete(Producto producto);
        IEnumerable<Producto> SearchProducto(string searchQuery);
        public void Deletet(Producto producto);
        Producto? GetcatById(int id);
        
        //definimos una propiedad filtroDelete de tipo IEnumerable<Producto> se usa para filtrar una lista de productos 
        IEnumerable<Producto> filtroDelete { get; }
        public IEnumerable<Producto> listaproducto();
        IEnumerable<Producto> productosList { get; }
        IEnumerable<Producto> AllProductos { get; }
    }
}
