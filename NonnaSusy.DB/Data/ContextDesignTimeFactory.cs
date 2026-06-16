using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.DB.Data
{
    public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            // Construye las opciones. Aquí debes usar la misma cadena de conexión
            // que usarías en tu aplicación real (pero puede ser una específica para diseño).
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            // Reemplaza "Server=...;Database=...;..." con tu cadena real.
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NonnaSusy;Trusted_Connection=True;MultipleActiveResultSets=true");


            return new Context(optionsBuilder.Options);
        }
    }
}
