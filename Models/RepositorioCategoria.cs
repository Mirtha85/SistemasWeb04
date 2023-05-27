using static SistemasWeb01.Models.InterfazCategoria;

namespace SistemasWeb01.Models
{
    public class RepositorioCategoria : InterfazCategoria
    {
       
            private readonly BdContexTiendaTecnoBoliviaSc _BdContexTiendaTecnoBoliviaSc;

            public RepositorioCategoria(BdContexTiendaTecnoBoliviaSc bdContexTiendaTecnoBoliviaSc)
            {
            _BdContexTiendaTecnoBoliviaSc = bdContexTiendaTecnoBoliviaSc;
            }
            public IEnumerable<Categoria> Categorias => _BdContexTiendaTecnoBoliviaSc.Categoriasdbcontex.ToList();
            /* Buscar por ID*/
            public Categoria GetcatById(int id)
            {
                return _BdContexTiendaTecnoBoliviaSc.Categoriasdbcontex.FirstOrDefault(p => p.CategoriaId == id);
            }
            public IEnumerable<Categoria> AllCategorias => _BdContexTiendaTecnoBoliviaSc.Categoriasdbcontex.OrderBy(p => p.NombreCategoria);
            public void CreateCategoria(Categoria categoria)
            {
                categoria.Productos = new List<Producto>();
            _BdContexTiendaTecnoBoliviaSc.Categoriasdbcontex.Add(categoria);
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();

            }
            public void UpdateCategoria(Categoria categoria)
            {
                categoria.Productos = new List<Producto>();
            _BdContexTiendaTecnoBoliviaSc.Categoriasdbcontex.Update(categoria);
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();

            }
            public void DeleteCategoria(Categoria categoria)
            {
                categoria.Productos = new List<Producto>();
            _BdContexTiendaTecnoBoliviaSc.Categoriasdbcontex.Remove(categoria);
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();

            }

        
    }
}
