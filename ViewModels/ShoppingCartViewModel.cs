using SistemasWeb01.Models;


namespace SistemasWeb01.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(InterfazShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }

        public InterfazShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
    }
}

