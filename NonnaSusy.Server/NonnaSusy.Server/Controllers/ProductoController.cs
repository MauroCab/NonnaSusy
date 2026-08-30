using Microsoft.AspNetCore.Mvc;
using NonnaSusy.DB.Data.Entities;
using NonnaSusy.Repositorio.Repositorio;

namespace NonnaSusy.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductoController : ControllerBase
    {
        private readonly IRepositorio<Producto> repositorio;

        public ProductoController(IRepositorio<Producto> repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet("ListaProductos")]
        public async Task<ActionResult<List<Producto>>> GetFull()
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
