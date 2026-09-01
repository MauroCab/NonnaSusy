using NonnaSusy.DB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.Shared.DTO
{
    public class CrearPedidoDTO
    {
        public int ClienteID { get; set; }

        public List<CrearRenglonDTO> RenglonesDTO { get; set; } = new List<CrearRenglonDTO>();
    }

    public class CrearRenglonDTO
    {
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
    }

    
}
