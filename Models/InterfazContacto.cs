namespace SistemasWeb01.Models
{
     public interface InterfazContacto
     {
        //IEnumerable ? permite acceder a mas metodos que Collection
        IEnumerable<Contacto> AllCantactos { get; }

        void CreateContacto(Contacto contacto);
     }
}
