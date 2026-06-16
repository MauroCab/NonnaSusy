using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.DB.Data.Entities
{
    public class Pedido : EntityBase
    {
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public DateOnly FechaPedido { get; set; }

        public List<Renglon> Renglones { get; set; } = new List<Renglon>();
    }
}
