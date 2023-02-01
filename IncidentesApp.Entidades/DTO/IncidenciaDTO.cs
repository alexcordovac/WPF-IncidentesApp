using IncidentesApp.Entidades.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Entidades.DTO
{
    public class IncidenteDTO
    {

        public IncidenteDTO()
        {
            this.CentroAtencion = new CentroAtencionDTO();
            this.TipoAsistencia = new TipoAsistenciaDTO();
        }

        public int IncidenteID { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public double DistanciaKM { get; set; }
        public string? DireccionCardinal { get; set; }
        public double TiempoEstimadoMinutos { get; set; }
        public DateTime? HoraEstimadaLlegada { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public TipoAsistenciaDTO TipoAsistencia { get; set; }
        public CentroAtencionDTO CentroAtencion { get; set; }
    }
}
