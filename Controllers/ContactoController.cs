using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;

namespace SistemasWeb01.Controllers
{
    public class ContactoController : Controller
    {
        private readonly InterfazContacto _contactoRepository;
        public ContactoController(InterfazContacto contactoRepository)
        {
            _contactoRepository = contactoRepository;
        }
        public IActionResult CreateContacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContacto(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _contactoRepository.CreateContacto(contacto);
                return RedirectToAction("ContactoCreated");
            }

            return View(contacto);

        }
        public IActionResult ContactoCreated()
        {
            ViewBag.ContactoCreatedMessage = "GRACIAS POR CONTACTARNOS";
            return View();
        }
    }
}
