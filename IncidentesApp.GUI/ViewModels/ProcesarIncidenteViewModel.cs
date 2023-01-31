using IncidentesApp.Entidades.DTO;
using IncidentesApp.GUI.Interfaces;
using IncidentesApp.GUI.Models;
using IncidentesApp.Servicios.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IncidentesApp.GUI.ViewModels
{
    internal class ProcesarIncidenteViewModel : BindableBase
    {
        private readonly IIncidenteService _incidenteService;

        public ProcesarIncidenteViewModel(IIncidenteService incidenteService)
        {
            this._incidenteService = incidenteService;

            this.Incidente = new IncidenciaModel();
            this.CancelarCommand = new DelegateCommand<IClosable>(this.CerrarWindow);
            this.GuardarCommand = new DelegateCommand<IClosable>(this.GuardarIncidente);

            this.ProcesarIncidente();
        }

        #region Comandos
        public DelegateCommand<IClosable> CancelarCommand { get; set; }
        public DelegateCommand<IClosable> GuardarCommand { get; set; }
        #endregion

        #region Propiedades

        private IncidenciaModel incidente;

        public IncidenciaModel Incidente
        {
            get { return incidente; }
            set { incidente = value; }
        }



        private Visibility cargandoEstacionVisibility = Visibility.Visible;

        public Visibility CargandoEstacionVisibility
        {
            get { return cargandoEstacionVisibility; }
            set
            {
                SetProperty(ref this.cargandoEstacionVisibility, value);
            }
        }

        private Visibility cargandoDistanciaVisibility = Visibility.Visible;

        public Visibility CargandoDistanciaVisibility
        {
            get { return cargandoDistanciaVisibility; }
            set { SetProperty(ref this.cargandoDistanciaVisibility, value); }
        }


        private Visibility cargandoDireccionCardinalVisibility = Visibility.Visible;

        public Visibility CargandoDireccionCardinalVisibility
        {
            get { return cargandoDireccionCardinalVisibility; }
            set { SetProperty(ref this.cargandoDireccionCardinalVisibility, value); }
        }

        private Visibility cargandoTEVisibility = Visibility.Visible;

        public Visibility CargandoTEVisibility
        {
            get { return cargandoTEVisibility; }
            set { SetProperty(ref this.cargandoTEVisibility, value); }
        }

        private Visibility cargandoHEVisibility = Visibility.Visible;

        public Visibility CargandoHEVisibility
        {
            get { return cargandoHEVisibility; }
            set { SetProperty(ref this.cargandoHEVisibility, value); }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Calcular los elementos restantes de la incidencia
        /// </summary>
        private async void ProcesarIncidente()
        {

            await Task.Delay(2000);

            //Cargar Centro de atención y distancia
            var incidentResponse = await this._incidenteService.CentroAtencionCercano(new IncidenteDTO() { Latitud = this.Incidente.Latitud, Longitud = this.Incidente.Longitud });

            this.Incidente.DistanciaKM = incidentResponse.DistanciaKM;
            this.Incidente.CentroAtencion = new CentroAtencionModel() { Nombre = incidentResponse.CentroAtencion.Nombre};

            this.CargandoEstacionVisibility = Visibility.Collapsed;
            this.CargandoDistanciaVisibility = Visibility.Collapsed;

            //Cargar dirección cardinal
            await Task.Delay(1000);
            await this._incidenteService.DireccionCardinal(incidentResponse);
            this.Incidente.DireccionCardinal = incidentResponse.DireccionCardinal;
            this.CargandoDireccionCardinalVisibility = Visibility.Collapsed;

            //Tiempo reccorido
            await Task.Delay(1000);
            await this._incidenteService.TiempoEstimado(incidentResponse);
            this.Incidente.TiempoEstimadoMinutos = incidentResponse.TiempoEstimadoMinutos;;
            this.CargandoTEVisibility = Visibility.Collapsed;

            //Hora estimada llegada
            await Task.Delay(1000);
            await this._incidenteService.HoraEstimada(incidentResponse);
            this.Incidente.HoraEstimadaLlegada = incidentResponse.HoraEstimadaLlegada.Value;
            this.CargandoHEVisibility= Visibility.Collapsed;
        }

        /// <summary>
        /// Cerrar la ventana
        /// </summary>
        /// <param name="win"></param>
        private void CerrarWindow(IClosable win)
        {
            win.Close();
        }

        /// <summary>
        /// Guardar incidente en la base de datos
        /// </summary>
        /// <param name="win"></param>
        private void GuardarIncidente(IClosable win)
        {

        }

        #endregion

    }
}
