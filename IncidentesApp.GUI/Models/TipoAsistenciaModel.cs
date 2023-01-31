using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.GUI.Models
{
    internal class TipoAsistenciaModel
    {
        public TipoAsistenciaModel(int id, string nombre, string icono)
        {
            this.TipoAsistenciaID = id;
            this.Nombre = nombre;
            this.Icono = icono;
        }

        public int TipoAsistenciaID { get; set; }

        public string Nombre { get; set; }

        public string Icono { get; set; }
    }
}
