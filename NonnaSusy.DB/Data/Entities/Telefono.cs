using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.DB.Data.Entities
{
    public class Telefono : EntityBase
    {
        public string NumeroTelefono { get; set; }

        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
    }
}
