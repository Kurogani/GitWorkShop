using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Newtonsoft.Json;
using InventarioTiWS.Services;
using InventarioTiWS.Data.Models;
using InventarioTiWS.Interfaces;

namespace InventarioTiWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _usuarioService;
        private readonly InventarioWebContext _context;
        // public UsuariosController(IUsuario usuarios) => _usuarioService = usuarios;
        public UsuariosController(InventarioWebContext context, IUsuario usuarios)
        {
            _context = context;
            _usuarioService = usuarios;
        }

        [HttpPost]
        [Route("Register/")]

        public ActionResult Register([FromBody] Usuario usuario)
        {
            var insertemp = _usuarioService.Register(usuario);
            return Ok(insertemp);
        }

        [HttpPost]
        [Route("GetUser/")]

        public async Task<IActionResult> GetUser([FromBody] Usuario usuario)
        {
            var RolExist = (from a in _context.Roles
                            where a.Id == usuario.Rol
                            select a).FirstOrDefault();
            if (RolExist == null)
            {
                return BadRequest(new { message = "Rol no existe" });

            }
            var user =await _usuarioService.GetUser(usuario);

            if (user.Codigo == null)
            {
                return BadRequest(new { message = "Usuario o contrase;a incorrectos" });

            }
            if (user.Codigo == usuario.Codigo)
            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                var resultado = new { Usuario = user, Token = tokenString };
                return Ok(resultado);

            }

            else
            {
                return Unauthorized();
            }

        }

    }
}
