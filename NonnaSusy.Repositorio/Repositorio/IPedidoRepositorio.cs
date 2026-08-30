using NonnaSusy.DB.Data.Entities;

namespace NonnaSusy.Repositorio.Repositorio
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        Task<int> InsertarPedido();
        Task<List<Pedido>> SelectListaPedidos();
    }
}