using IncidentesApp.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Entidades.Solicitud
{
    public class UsuarioDTO
    {
        public UsuarioDTO()
        {
            this.Persona = new PersonaDTO();
            this.Rol = new RolDTO();
        }

        public UsuarioDTO(string usuario, string contraseña)
        {
            this.Usuario = usuario;
            this.Contraseña = contraseña;
        }

        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public PersonaDTO Persona { get; set; }
        public RolDTO Rol { get; set; }
    }
}
