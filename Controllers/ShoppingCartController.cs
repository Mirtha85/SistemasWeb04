using SistemasWeb01.Models;
using SistemasWeb01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;

namespace SistemasWeb01.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly InterfazProducto _Repositorioproducto;
        private readonly InterfazShoppingCart _shoppingCart;

        public ShoppingCartController(InterfazProducto repositorioproducto, InterfazShoppingCart shoppingCart)
        {
            _Repositorioproducto = repositorioproducto;
            _shoppingCart = shoppingCart;

        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int productoId)
        {
            var selectedPie = _Repositorioproducto.productosList.FirstOrDefault(p => p.ProductoId == productoId);

            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productoId)
        {
            var selectedPie = _Repositorioproducto.productosList.FirstOrDefault(p => p.ProductoId == productoId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
