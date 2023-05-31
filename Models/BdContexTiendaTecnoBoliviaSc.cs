using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.IO.Pipelines;

namespace SistemasWeb01.Models
{
    public class BdContexTiendaTecnoBoliviaSc : DbContext
    {
        //creamos una funcion de tipo dbcontex para manipular la base de datos 
        public BdContexTiendaTecnoBoliviaSc(DbContextOptions<BdContexTiendaTecnoBoliviaSc> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Categoria> Categoriasdbcontex { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        // public DbSet<Contacto> Contactosdbcontex { get; set; }
        public DbSet<Producto> Productosdbcontex { get; set; }
    }
}
