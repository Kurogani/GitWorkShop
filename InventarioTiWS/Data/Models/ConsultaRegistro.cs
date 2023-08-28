using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class ConsultaRegistro
    {
        public int Id { get; set; }
        public string? Equipo { get; set; }
        public string DetalleEquipo { get; set; } = null!;
        public string? TipoRegistro { get; set; }
        public string? Estado { get; set; }
        public string? Usuario { get; set; }
        public string? Tecnico { get; set; }
        public string? Casos { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
