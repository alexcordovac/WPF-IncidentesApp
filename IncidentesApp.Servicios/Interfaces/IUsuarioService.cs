using IncidentesApp.Entidades.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Servicios.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> Autenticar(UsuarioDTO usuario);
    }
}
