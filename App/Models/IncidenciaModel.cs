using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.GUI.Models
{
    internal class IncidenciaModel
    {
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
