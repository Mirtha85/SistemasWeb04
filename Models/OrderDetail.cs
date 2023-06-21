namespace SistemasWeb01.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductoId { get; set; }
        public int Amount { get; set; }
        public decimal Precio { get; set; }
        public Producto producto { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
