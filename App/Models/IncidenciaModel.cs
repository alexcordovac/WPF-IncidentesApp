using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.GUI.Models
{
    internal class IncidenciaModel : BindableBase
    {

        public IncidenciaModel()
        {
            this.CentroAtencion = new CentroAtencionModel();
        }


        private CentroAtencionModel centroAtencion;

        public CentroAtencionModel CentroAtencion
        {
            get { return centroAtencion; }
            set { SetProperty(ref this.centroAtencion, value); }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { SetProperty(ref this.descripcion, value); }
        }


        private string lugar;

        public string Lugar
        {
            get { return lugar; }
            set { SetProperty(ref this.lugar, value); }
        }

        private double latitud;

        public double Latitud
        {
            get { return latitud; }
            set { SetProperty(ref this.latitud, value); }
        }

        private double longitud;

        public double Longitud
        {
            get { return longitud; }
            set { SetProperty(ref this.longitud, value); }
        }

    }
}
