using Microsoft.AspNetCore.Mvc;
using NonnaSusy.DB.Data.Entities;
using NonnaSusy.Repositorio.Repositorio;

namespace NonnaSusy.Server.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorio<Cliente> repositorio;

        public ClienteController(IRepositorio<Cliente> repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet("ListaClientes")] //api/Cliente
        public async Task<ActionResult<List<Cliente>>> GetFull()
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
    }
}
