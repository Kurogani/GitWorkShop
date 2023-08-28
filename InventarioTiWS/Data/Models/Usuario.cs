using System;
using System.Collections.Generic;

namespace InventarioTiWS.Data.Models
{
    public partial class Usuario
    {
        /* public Usuario()
         {
             Proveedors = new HashSet<Proveedor>();
         }
        */
        //   public int id { get; set; }
        public string Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Contrasena { get; set; }
        public string? Descripcion { get; set; }
        public int? Estado { get; set; }
        public int Rol { get; set; }
        public string? Salt { get; set; }

        public virtual Estado? EstadoNavigation { get; set; }
        public virtual Role? RolNavigation { get; set; }
      //  public virtual ICollection<Proveedor> Proveedors { get; set; }
    }
}
