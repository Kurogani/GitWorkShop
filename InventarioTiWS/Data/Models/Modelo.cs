using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class Modelo
    {
        public int Id { get; set; }
        public string? ModeloNombre { get; set; }
        public int? MarcaId { get; set; }

        public virtual Marca? Marca { get; set; }
    }
}
