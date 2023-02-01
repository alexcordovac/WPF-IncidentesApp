using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Entidades.DTO
{
    public class CentroAtencionDTO
    {
        public CentroAtencionDTO()
        {
            this.Coordenadas = new CoordenadasDTO();
        }

        public int CentroAtencionID { get; set; }
        public string Nombre { get; set; }
        public CoordenadasDTO Coordenadas { get; set; }
    }
}
