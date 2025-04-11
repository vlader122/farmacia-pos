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
    [Authorize]
    public class VentaController : ControllerBase
    {
        private readonly VentaService _ventaService;
        public VentaController(VentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetAll(int numeroPagina = 1, int tamañoPagina = 10)
        {
            if (numeroPagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("La paginacion es incorrecta revise e intente nuevamente.");
            }

            List<Venta> ventas;
            int totalRegistros;
            (ventas, totalRegistros) = await _ventaService.GetAll(numeroPagina, tamañoPagina);
            ResponsePaginado<Venta> response = new ResponsePaginado<Venta>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Dato = ventas
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetById(int id)
        {
            return Ok(await _ventaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venta venta)
        {
            return Ok(await _ventaService.Create(venta));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Venta venta)
        {
            return Ok(await _ventaService.Update(venta));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ventaService.Delete(id);
            return Ok();
        }
    }
}
