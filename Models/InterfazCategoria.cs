namespace SistemasWeb01.Models
{
    public interface InterfazCategoria
    {
        
            //IEnumerable ? permite acceder a mas metodos que Collection
            IEnumerable<Categoria> AllCategorias { get; }
            IEnumerable<Categoria> Categorias { get; }
            void CreateCategoria(Categoria categoria);
            void UpdateCategoria(Categoria categoria);
            void DeleteCategoria(Categoria categoria);

            //método que se utiliza para obtener información de un objeto de
            //tipo "Cat" (gato) a partir de su identificador único o ID.
            Categoria? GetcatById(int productoId);
        
    }
}
