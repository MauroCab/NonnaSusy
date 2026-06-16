using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.DB.Data.Entities
{
    public class Cliente : EntityBase
    {
        public string NombreCliente { get; set; }

        public string Direccion { get; set; }

        public List<Telefono> Telefonos { get; set; } = new List<Telefono>();
    }
}
