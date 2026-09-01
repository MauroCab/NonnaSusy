using Microsoft.AspNetCore.Mvc;
using NonnaSusy.DB.Data.Entities;
using NonnaSusy.Repositorio.Repositorio;
using NonnaSusy.Shared.DTO;

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
            var lista = await repositorio.SelectListaPedidos();
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
        public async Task<ActionResult<int>> Post(CrearPedidoDTO pedidoDTO)
        {
            bool pedidoEstaVacio = pedidoDTO == null || pedidoDTO.RenglonesDTO == null || !pedidoDTO.RenglonesDTO.Any();

            if (pedidoEstaVacio)
            {
                return BadRequest("El pedido debe contener al menos un renglón.");
            }

            try
            {
                var nuevoPedido = new Pedido
                {
                    ClienteID = pedidoDTO.ClienteID,
                    FechaPedido = DateOnly.FromDateTime(DateTime.Now.Date + TimeSpan.FromDays(1))
                };

                    
                var renglones = pedidoDTO.RenglonesDTO.Select(r => new Renglon
                {
                    Cantidad = r.Cantidad,
                    ProductoID = r.ProductoID
                }).ToList();

                var pedidoCreadoID = await repositorio.InsertarPedido(nuevoPedido, renglones);

                return Ok(pedidoCreadoID);    
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el pedido: {ex.Message}");
            }

        }
    }
}
