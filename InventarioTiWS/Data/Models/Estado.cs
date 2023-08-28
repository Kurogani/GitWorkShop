using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
