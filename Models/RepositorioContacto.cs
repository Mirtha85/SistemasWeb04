namespace SistemasWeb01.Models
{
    public class RepositorioContacto : InterfazContacto
    {
        private readonly BdContexTiendaTecnoBoliviaSc _BdContexTiendaTecnoBoliviaSc;

        public RepositorioContacto(BdContexTiendaTecnoBoliviaSc bdContexTiendaTecnoBoliviaSc)
        {
            _BdContexTiendaTecnoBoliviaSc = bdContexTiendaTecnoBoliviaSc;
        }

        public IEnumerable<Contacto> AllCantactos => _BdContexTiendaTecnoBoliviaSc.Contactosdbcontex.OrderBy(c => c.NombreContacto);

        public void CreateContacto(Contacto contacto)
        {

            _BdContexTiendaTecnoBoliviaSc.Contactosdbcontex.Add(contacto);
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();

        }
    }
}
