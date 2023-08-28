using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class EstadosTabla
    {
        public int Id { get; set; }
        public int? IdEstado { get; set; }
        public string? Tabla { get; set; }
    }
}
