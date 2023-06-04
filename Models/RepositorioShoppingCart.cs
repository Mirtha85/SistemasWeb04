using SistemasWeb01.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemasWeb01.Models
{
    public class RepositorioShoppingCart : InterfazShoppingCart
    {
        private readonly BdContexTiendaTecnoBoliviaSc _BdContexTiendaTecnoBoliviaSc;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        //porqeu se inyecta
        private RepositorioShoppingCart(BdContexTiendaTecnoBoliviaSc bdContexTiendaTecnoBoliviaSc)
        {
            _BdContexTiendaTecnoBoliviaSc = bdContexTiendaTecnoBoliviaSc;
        }
        /*This method we didn't have on our interface, it is a static method
         * It will return me a fully created ShoppingCart
         * I am passing a services colletion
         * When the user visits the site this code is going to run and it's going to check if there is already
         * and ID called CartId available for the user.If not the will create a new GUID and restore the values as the CartId.
         * When the user is returning, we'll be able to find the existing CartId and we'll use that.
         */
        public static RepositorioShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            BdContexTiendaTecnoBoliviaSc context = services.GetService<BdContexTiendaTecnoBoliviaSc>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new RepositorioShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Producto producto)
        {
            var shoppingCartItem =
                    _BdContexTiendaTecnoBoliviaSc.ShoppingCartItems.SingleOrDefault(
                        s => s.producto.ProductoId == producto.ProductoId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    producto = producto,
                    Amount = 1
                };

                _BdContexTiendaTecnoBoliviaSc.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _BdContexTiendaTecnoBoliviaSc.SaveChanges();
        }

        public int RemoveFromCart(Producto producto)
        {
            var shoppingCartItem =
                    _BdContexTiendaTecnoBoliviaSc.ShoppingCartItems.SingleOrDefault(
                        s => s.producto.ProductoId == producto.ProductoId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _BdContexTiendaTecnoBoliviaSc.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _BdContexTiendaTecnoBoliviaSc.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                        _BdContexTiendaTecnoBoliviaSc.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                            .Include(s => s.producto)
                            .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _BdContexTiendaTecnoBoliviaSc
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _BdContexTiendaTecnoBoliviaSc.ShoppingCartItems.RemoveRange(cartItems);

            _BdContexTiendaTecnoBoliviaSc.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _BdContexTiendaTecnoBoliviaSc.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .ToList() // force to handle it as C# object
                .Select(c => c.producto.PrecioProducto * c.Amount).Sum();
            return total;
        }
    }
}
