using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using InventarioTiWS.Data.Models;
using InventarioTiWS.Interfaces;
using InventarioTiWS.Controllers;

namespace InventarioTiWS.Services
{
    public class UsuarioService : IUsuario
    {
        private readonly InventarioWebContext _context;
        public UsuarioService(InventarioWebContext context) => _context = context;

        public async Task<Usuario> GetUser(Usuario usuario)
        {

            var query = (from a in _context.Usuarios
                         where a.Codigo == usuario.Codigo
                         select a).FirstOrDefault();

            if (query != null)
            {
                var validarpassword = ValidarContrasena(usuario.Contrasena, query.Contrasena, query.Salt);

                if (validarpassword)
                {
                    return query;

                }
                /*else
                {
                    return null;
                }*/
            }

            return null;

        }
        public async Task<Usuario> Register(Usuario usuario)
        {
            Usuario usertbl = new Usuario();
            var passwordog = usuario.Contrasena;

            var salt = CrearSalt();
            var passwordhashed = GenerarHash(passwordog, salt);
            var user = usuario;
            var password = usuario.Contrasena;
            var nombre = usuario.Nombre;

            usertbl.Codigo = usuario.Codigo;
            usertbl.Contrasena = passwordhashed;
            usertbl.Salt = salt;
            usertbl.Nombre = nombre;
            usertbl.Rol = usuario.Rol;
            _context.Usuarios.AddAsync(usertbl);
            _context.SaveChanges();

            return usertbl;
        }


        public static string CrearSalt()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] buff = new byte[128 / 8];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }


        public static string GenerarHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256 sHA256ManagedString = SHA256.Create();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public bool ValidarContrasena(string password, string stringHash, string salt)
        {
            string pass = password.ToString();
            string newHashedPin = GenerarHash(pass, salt);
            return newHashedPin.Equals(stringHash);
        }

    }
}