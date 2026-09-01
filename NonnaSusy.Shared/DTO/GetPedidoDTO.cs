using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.Shared.DTO
{
    public class GetPedidoDTO
    {
        public string NombreCliente { get; set; }
        public DateOnly FechaPedido { get; set; }
        public List<GetRenglonDTO> RenglonesDTO { get; set; }
    }

    public class GetRenglonDTO
    {
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
    }
}
