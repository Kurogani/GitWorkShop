using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class ItemTipo
    {
        public ItemTipo()
        {
            Validaciones = new HashSet<Validacione>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Prefijos { get; set; }

        public virtual ICollection<Validacione> Validaciones { get; set; }
    }
}
