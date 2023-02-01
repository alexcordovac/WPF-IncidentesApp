using IncidentesApp.Entidades.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.GUI.Interfaces
{
    internal interface ISessionContext
    {
        UsuarioDTO Usuario { get; set; }
    }
}
