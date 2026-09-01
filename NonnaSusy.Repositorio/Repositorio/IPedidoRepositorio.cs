using NonnaSusy.DB.Data.Entities;

namespace NonnaSusy.Repositorio.Repositorio
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        Task<int> InsertarPedido(Pedido pedido, List<Renglon> renglones);
        Task<List<Pedido>> SelectListaPedidos();
    }
}