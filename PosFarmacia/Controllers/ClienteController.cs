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
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll(int numeroPagina = 1, int tamañoPagina = 10)
        {
            if (numeroPagina <1 || tamañoPagina <1)
            {
                return BadRequest("La paginacion es incorrecta revise e intente nuevamente.");
            }

            List<Cliente> clientes;
            int totalRegistros;
            (clientes, totalRegistros) = await _clienteService.GetAll(numeroPagina, tamañoPagina);
            ResponsePaginado<Cliente> response = new ResponsePaginado<Cliente>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Dato = clientes
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            return Ok(await _clienteService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            return Ok(await _clienteService.Create(cliente));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            return Ok(await _clienteService.Update(cliente));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.Delete(id);
            return Ok();
        }
    }
}
