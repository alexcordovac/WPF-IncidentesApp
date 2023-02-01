using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.Entidades.DTO
{
    public class TipoAsistenciaDTO
    {
        public int TipoAsistenciaID { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
