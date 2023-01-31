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

        private double distanciaKM;

        public double DistanciaKM
        {
            get { return distanciaKM; }
            set { SetProperty(ref this.distanciaKM, value); }
        }

        private string direccionCardinal;

        public string DireccionCardinal
        {
            get { return direccionCardinal; }
            set { SetProperty(ref this.direccionCardinal, value); }
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

        private double tiempoEstimadoMinutos;

        public double TiempoEstimadoMinutos
        {
            get { return tiempoEstimadoMinutos; }
            set { SetProperty(ref this.tiempoEstimadoMinutos, value); }
        }

        private DateTime horaEstimadaLlegada;

        public DateTime HoraEstimadaLlegada
        {
            get { return horaEstimadaLlegada; }
            set { SetProperty(ref this.horaEstimadaLlegada, value); }
        }


    }
}
