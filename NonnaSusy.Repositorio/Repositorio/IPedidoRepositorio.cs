using NonnaSusy.DB.Data.Entities;
using NonnaSusy.Shared.DTO;

namespace NonnaSusy.Repositorio.Repositorio
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        Task<int> InsertarPedido(Pedido pedido, List<Renglon> renglones);
        Task<List<GetPedidoDTO>> SelectListaPedidos();
    }
}