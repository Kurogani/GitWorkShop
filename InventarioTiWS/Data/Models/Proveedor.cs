using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class Proveedor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Contacto { get; set; }
        public string? Obs { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? Tecnico { get; set; }

        public virtual Usuario? TecnicoNavigation { get; set; }
    }
}
