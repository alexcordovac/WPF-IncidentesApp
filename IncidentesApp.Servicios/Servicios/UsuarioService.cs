using IncidentesApp.Entidades.Solicitud;
using IncidentesApp.Repositorios.Interfaces;
using IncidentesApp.Repositorios.Repositorios;
using IncidentesApp.Servicios.Encriptacion;
using IncidentesApp.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Servicios.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository; 

        public UsuarioService(IUsuarioRepository usuarioRepository) 
        {
            this._usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Validar credenciales ingresadas del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>True si las credenciales son válidas</returns>
        public async Task<bool> Autenticar(UsuarioDTO usuario)
        {
            UsuarioDTO usu = await this._usuarioRepository.ObtenerUsuario(usuario.Usuario);

            var conEncriptada = EncriptacionService.StringToSHA2_512(usuario.Contraseña);

            return usu.Contraseña.Equals(conEncriptada);
        }
    }
}
