using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PosFarmacia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetalleVentaController : ControllerBase
    {
        private readonly DetalleVentaService _detalleVentaService;
        public DetalleVentaController(DetalleVentaService detalleVentaService)
        {
            _detalleVentaService = detalleVentaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVenta>>> GetAll()
        {
            return Ok(await _detalleVentaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVenta>> GetById(int id)
        {
            return Ok(await _detalleVentaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(DetalleVenta detalleVenta)
        {
            return Ok(await _detalleVentaService.Create(detalleVenta));
        }

        [HttpPut]
        public async Task<IActionResult> Update(DetalleVenta detalleVenta)
        {
            return Ok(await _detalleVentaService.Update(detalleVenta));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _detalleVentaService.Delete(id);
            return Ok();
        }
    }
}
