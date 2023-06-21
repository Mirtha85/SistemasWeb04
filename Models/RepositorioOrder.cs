namespace SistemasWeb01.Models
{
    public class RepositorioOrder :InterfazOrder
    {
        private readonly BdContexTiendaTecnoBoliviaSc _BdContexTiendaTecnoBoliviaSc;

        private readonly InterfazShoppingCart _shoppingCart;

        public RepositorioOrder(BdContexTiendaTecnoBoliviaSc bdContexTiendaTecnoBoliviaSc ,InterfazShoppingCart shoppingCart)
        {
            _BdContexTiendaTecnoBoliviaSc = bdContexTiendaTecnoBoliviaSc;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProductoId = shoppingCartItem.producto.ProductoId,
                    Precio = shoppingCartItem.producto.PrecioProducto
                };

                order.OrderDetails.Add(orderDetail);
            }

            _BdContexTiendaTecnoBoliviaSc.Orders.Add(order);

            _BdContexTiendaTecnoBoliviaSc.SaveChanges();
        }

    }
}
