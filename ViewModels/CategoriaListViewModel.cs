using SistemasWeb01.Models;

namespace SistemasWeb01.ViewModels
{
    public class CategoriaListViewModel
    {
        public IEnumerable<Categoria> Categorias { get; }
        

        public CategoriaListViewModel(IEnumerable<Categoria> categorias)
        {
            Categorias = categorias;
            
        }
    }
}
