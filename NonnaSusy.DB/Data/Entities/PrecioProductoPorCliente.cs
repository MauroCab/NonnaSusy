using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.DB.Data.Entities
{
    public class PrecioProductoPorCliente : EntityBase
    {
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }

        public decimal Precio { get; set; }
    }
}
