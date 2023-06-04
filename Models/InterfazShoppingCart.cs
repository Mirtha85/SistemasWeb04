using SistemasWeb01.Models;

namespace SistemasWeb01.Models
{
    public interface InterfazShoppingCart
    {
        void AddToCart(Producto producto);
        int RemoveFromCart(Producto producto);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
