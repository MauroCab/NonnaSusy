using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.DB.Data.Entities
{
    public class Producto : EntityBase
    {
        public string NombreProducto { get; set; }
        public decimal PrecioBase { get; set; }
        public string Descripcion { get; set; }
    }
}
