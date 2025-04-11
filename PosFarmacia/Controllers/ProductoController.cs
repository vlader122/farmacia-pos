using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PosFarmacia.helpers;
using Service;

namespace PosFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll(int numeroPagina = 1, int tamañoPagina = 10)
        {
            if (numeroPagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("La paginacion es incorrecta revise e intente nuevamente.");
            }

            List<Producto> productos;
            int totalRegistros;
            (productos, totalRegistros) = await _productoService.GetAll(numeroPagina, tamañoPagina);
            ResponsePaginado<Producto> response = new ResponsePaginado<Producto>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Dato = productos
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            return Ok(await _productoService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            return Ok(await _productoService.Create(producto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Producto producto)
        {
            return Ok(await _productoService.Update(producto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productoService.Delete(id);
            return Ok();
        }
    }
}
