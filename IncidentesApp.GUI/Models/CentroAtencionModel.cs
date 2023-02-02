using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.GUI.Models
{
    internal class CentroAtencionModel : BindableBase
    {


        private int centroAtencionID;

        public int CentroAtencionID
        {
            get { return centroAtencionID; }
            set { SetProperty(ref this.centroAtencionID, value); }
        }


        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref this.nombre, value); }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { SetProperty(ref this.descripcion, value); }
        }

    }
}
