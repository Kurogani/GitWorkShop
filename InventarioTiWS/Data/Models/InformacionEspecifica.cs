using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class InformacionEspecifica
    {
        public int Id { get; set; }
        public string? NombreItem { get; set; }
        public string? InfoDescripcion { get; set; }
        public string? Informacion { get; set; }
        public DateTime? InfoFecha { get; set; }
        public int? Estado { get; set; }
        public string? Obs { get; set; }
    }
}
