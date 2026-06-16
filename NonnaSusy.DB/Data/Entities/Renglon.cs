using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.DB.Data.Entities
{
    public class Renglon : EntityBase
    {
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; }

        public int ProductoID { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
    }
}
