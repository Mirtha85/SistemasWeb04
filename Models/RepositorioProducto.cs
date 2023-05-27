﻿using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;
namespace SistemasWeb01.Models

{
    public class RepositorioProducto : InterfazProducto

    {
        private readonly BdContexTiendaTecnoBoliviaSc _BdContexTiendaTecnoBoliviaSc;

        public RepositorioProducto(BdContexTiendaTecnoBoliviaSc bdContexTiendaTecnoBoliviaSc)
        {
            _BdContexTiendaTecnoBoliviaSc = bdContexTiendaTecnoBoliviaSc;
        }
        public Producto GetcatById(int id)
        {
            return _BdContexTiendaTecnoBoliviaSc.Productosdbcontex.FirstOrDefault(p => p.ProductoId == id);
        }
        public void agregar(Producto producto)
        {
            _BdContexTiendaTecnoBoliviaSc.Productosdbcontex.Add(producto);
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();
        }
        public void Update(Producto producto)
        {
            

            _BdContexTiendaTecnoBoliviaSc.Productosdbcontex.Update(producto);
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();

        }
        public void Delete(Producto producto)
        {
            
            _BdContexTiendaTecnoBoliviaSc.Productosdbcontex.Remove(producto);
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();

        }
        public void Deletet(Producto producto)
        {

            _BdContexTiendaTecnoBoliviaSc.Productosdbcontex.Update(producto);
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();

        }
        /* LLama a todos los productos */
        public IEnumerable<Producto> productosList => _BdContexTiendaTecnoBoliviaSc.Productosdbcontex.ToList();
        public IEnumerable<Producto> filtroDelete => _BdContexTiendaTecnoBoliviaSc.Productosdbcontex.Where(p => p.Deleted == true).ToList();
        public IEnumerable<Producto> listaproducto()
        {
            return _BdContexTiendaTecnoBoliviaSc.Productosdbcontex.ToList();
        }
    }
}
