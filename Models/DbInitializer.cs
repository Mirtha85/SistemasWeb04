namespace SistemasWeb01.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            BdContexTiendaTecnoBoliviaSc context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BdContexTiendaTecnoBoliviaSc>();

            if (!context.Categoriasdbcontex.Any())
            {
                context.Categoriasdbcontex.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Productosdbcontex.Any())
            {
                context.AddRange
                (
                    new Producto { NombreProducto = "ryzen", PrecioProducto = 22.95M, DescripcionProducto = "The ultimate cheese cake", Categoria = Categories["Procesador"], ImagenProducto = "~/imagenes/51gCXtjJKhL._AC_SX679_.jpg", },
                    new Producto { NombreProducto = "intel", PrecioProducto = 19.95M, DescripcionProducto = "The chocolate lover's dream", Categoria = Categories["Procesador"], ImagenProducto = "~/imagenes/51gCXtjJKhL._AC_SX679_.jpg" }

                ) ;
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Categoria>? categories;

        public static Dictionary<string, Categoria> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Categoria[]
                    {
                        new Categoria { NombreCategoria = "Procesador" },
                      
                    };

                    categories = new Dictionary<string, Categoria>();

                    foreach (Categoria genre in genresList)
                    {
                        categories.Add(genre.NombreCategoria, genre);
                    }
                }

                return categories;
            }
        }
    }
}
