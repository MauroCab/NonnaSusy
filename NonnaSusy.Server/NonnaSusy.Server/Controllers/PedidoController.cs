using Microsoft.AspNetCore.Mvc;
using NonnaSusy.DB.Data.Entities;
using NonnaSusy.Repositorio.Repositorio;

namespace NonnaSusy.Server.Controllers
{
    [ApiController]
    [Route("api/Pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio repositorio;

        public PedidoController(IPedidoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet] //api/Pedido
        public async Task<ActionResult<List<Pedido>>> GetFull()
        {
            var lista = await repositorio.Select();
            if (lista == null)
            {
                return NotFound("No se encontro elementos de la lista, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return Ok("Lista sin registros.");
            }

            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post()
        {
            return BadRequest();
        }

        [HttpPut("{id:int}")]  // api/Pedido/6
        public async Task<ActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete("{id:int}")]  // api/Pedido/6
        public async Task<ActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
