using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;
using System.IO.Pipelines;

namespace SistemasWeb01.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly InterfazProducto _ProductoRepository;

        public SearchController(InterfazProducto ProductoRepository)
        {
            _ProductoRepository = ProductoRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var allProductos = _ProductoRepository.AllProductos;
            return Ok(allProductos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_ProductoRepository.AllProductos.Any(p => p.ProductoId == id))
                return NotFound();
            //return new JsonResult(_pieRepository.AllPies.Where(p =>p.PieId == id);
            return Ok(_ProductoRepository.AllProductos.Where(p => p.ProductoId == id));
        }

        [HttpPost]
        public IActionResult SearchProducto([FromBody] string searchQuery)
        {
            IEnumerable<Producto> productos = new List<Producto>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                productos = _ProductoRepository.SearchProducto(searchQuery);
            }
            return new JsonResult(productos);
        }
    }
}
