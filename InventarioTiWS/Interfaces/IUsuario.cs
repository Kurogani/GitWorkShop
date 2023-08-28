using InventarioTiWS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioTiWS.Interfaces
{
    public interface IUsuario
    {
        Task<Usuario> GetUser(Usuario usuario);
        Task<Usuario> Register(Usuario usuario);
    }
}
