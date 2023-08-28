using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class Validacione
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? TipoItem { get; set; }
        public int? CarecteresMin { get; set; }
        public int? CaracteresMax { get; set; }
        public int? Numerico { get; set; }
        public int? Obligatorio { get; set; }

        public virtual ItemTipo? TipoItemNavigation { get; set; }
    }
}
