using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class Registro
    {
        public int Id { get; set; }
        public int? TipoRegistro { get; set; }
        public string? Equipo { get; set; }
        public int? Proveedor { get; set; }
        public int? Estado { get; set; }
        public string? Usuario { get; set; }
        public int? Ubicacion { get; set; }
        public int? Localidad { get; set; }
        public string? Obs { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string? Casos { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? Tecnico { get; set; }
    }
}
