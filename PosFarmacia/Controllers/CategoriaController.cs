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
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;
        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAll(int numeroPagina = 1, int tamañoPagina = 10)
        {
            if (numeroPagina < 1 || tamañoPagina < 1)
            {
                return BadRequest("La paginacion es incorrecta revise e intente nuevamente.");
            }

            List<Categoria> categorias;
            int totalRegistros;
            (categorias, totalRegistros) = await _categoriaService.GetAll(numeroPagina, tamañoPagina);
            ResponsePaginado<Categoria> response = new ResponsePaginado<Categoria>
            {
                TotalRegistros = totalRegistros,
                NumeroPagina = numeroPagina,
                TamanioPagina = tamañoPagina,
                Dato = categorias
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetById(int id)
        {
            return Ok(await _categoriaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            return Ok(await _categoriaService.Create(categoria));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Categoria categoria)
        {
            return Ok(await _categoriaService.Update(categoria));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriaService.Delete(id);
            return Ok();
        }
    }
}
