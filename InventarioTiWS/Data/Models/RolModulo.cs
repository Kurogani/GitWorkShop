using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class RolModulo
    {
        public int Id { get; set; }
        public int? IdRol { get; set; }
        public int? IdModulo { get; set; }
    }
}
