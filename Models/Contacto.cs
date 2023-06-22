namespace SistemasWeb01.Models
{
    public class Contacto
    {
        public int ContactoId { get; set; }
        public string NombreContacto { get; set; } = string.Empty;
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public string? Mensaje { get; set; }
    }
}
