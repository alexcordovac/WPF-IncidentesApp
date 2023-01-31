using IncidentesApp.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Servicios.Interfaces
{
    public interface IIncidenteService
    {
        Task<IncidenteDTO> CentroAtencionCercano(IncidenteDTO incidente);
        Task<IncidenteDTO> DireccionCardinal(IncidenteDTO incidente);
        Task<IncidenteDTO> TiempoEstimado(IncidenteDTO incidente);
        Task<IncidenteDTO> HoraEstimada(IncidenteDTO incidente);
    }
}
