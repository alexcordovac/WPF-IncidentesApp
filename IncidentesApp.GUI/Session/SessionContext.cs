using IncidentesApp.Entidades.Solicitud;
using IncidentesApp.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.GUI.Session
{
    internal class SessionContext : ISessionContext
    {
        public UsuarioDTO Usuario { get; set; }
    }
}
