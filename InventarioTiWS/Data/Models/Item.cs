using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int? ItemTipo { get; set; }
        public string NoSerie { get; set; } = null!;
        public int? Modelo { get; set; }
        public int? Marca { get; set; }
        public string? Obs { get; set; }
        public int? Estado { get; set; }
        public DateTime? RegistroFecha { get; set; }
        public string? Usuario { get; set; }
        public string? CodigoItem { get; set; }
        public DateTime? FechaAdquisicion { get; set; }
        public int? Proveedor { get; set; }
        public decimal? PrecioCompra { get; set; }
        public string? Moneda { get; set; }
    }
}
