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
        public int UsuarioID { get; set; }
        public int TipoAsistenciaID { get; set; }
        public CentroAtencionDTO CentroAtencion { get; set; }
    }
}
