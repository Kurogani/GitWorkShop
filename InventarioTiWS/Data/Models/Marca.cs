using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int Id { get; set; }
        public string? MarcaNombre { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
