namespace SistemasWeb01.Models
{
    public interface InterfazOrder
    {
        void CreateOrder(Order order);
        void correoSend(string informacion, string Email);
        string detalleOrden(Order order);
    }
}
