﻿using IncidentesApp.Entidades.DTO;
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

        }

        public UsuarioDTO(string usuario, string contraseña)
        {
            this.Usuario = usuario;
            this.Contraseña = contraseña;
        }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public RolDTO Rol { get; set; }
    }
}
