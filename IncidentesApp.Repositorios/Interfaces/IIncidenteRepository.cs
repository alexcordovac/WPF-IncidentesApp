using IncidentesApp.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Repositorios.Interfaces
{
    public interface IIncidenteRepository
    {
        Task<int> Guardar(IncidenteDTO incidente);

        Task<IEnumerable<IncidenteDTO>> FiltrarPorIDCentroMonitoreo(int centroAtencionID);
    }
}
