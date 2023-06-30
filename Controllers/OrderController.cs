using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;

namespace SistemasWeb01.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly InterfazOrder _orderRepository;
        private readonly InterfazShoppingCart _shoppingCart;

        public OrderController(InterfazOrder orderRepository, InterfazShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()//GET, default.
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                string texto = _orderRepository.detalleOrden(order);
                string number = order.PhoneNumber;
                _orderRepository.correoSend(texto, order.Email);
                _shoppingCart.ClearCart();
                return RedirectToAction("Mensajepro", "Producto");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious !";
            return View();
        }
    }
}
