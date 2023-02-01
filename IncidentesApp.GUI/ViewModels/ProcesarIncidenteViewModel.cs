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
using System.Windows.Input;

namespace IncidentesApp.GUI.ViewModels
{
    internal class ProcesarIncidenteViewModel : BindableBase
    {
        private readonly IIncidenteService _incidenteService;
        private readonly ISessionContext _variablesSession;

        public ProcesarIncidenteViewModel(IIncidenteService incidenteService, ISessionContext variablesSession)
        {
            _incidenteService = incidenteService;
            _variablesSession = variablesSession;

            this.Incidente = new IncidenciaModel();
            this.CancelarCommand = new DelegateCommand<IClosable>(this.CerrarWindow);
            this.GuardarCommand = new DelegateCommand<IClosable>(this.GuardarIncidente);

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
            set { SetProperty(ref this.incidente, value); }
        }


        public bool EsIncidenteGuardado { get; set; } = false;

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
        public async Task ProcesarIncidente()
        {
            try
            {
                await Task.Delay(2000);

                //Cargar Centro de atención y distancia
                var incidentResponse = await this._incidenteService.CentroAtencionCercano(new IncidenteDTO() { Latitud = this.Incidente.Latitud, Longitud = this.Incidente.Longitud });

                this.Incidente.DistanciaKM = incidentResponse.DistanciaKM;
                this.Incidente.CentroAtencion = new CentroAtencionModel() { Nombre = incidentResponse.CentroAtencion.Nombre, CentroAtencionID = incidentResponse.CentroAtencion.CentroAtencionID };

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
                this.Incidente.TiempoEstimadoMinutos = incidentResponse.TiempoEstimadoMinutos;
                this.CargandoTEVisibility = Visibility.Collapsed;

                //Hora estimada llegada
                await Task.Delay(1000);
                await this._incidenteService.HoraEstimada(incidentResponse);
                this.Incidente.HoraEstimadaLlegada = incidentResponse.HoraEstimadaLlegada.Value;
                this.CargandoHEVisibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
        private async void GuardarIncidente(IClosable win)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                IncidenteDTO dto = new IncidenteDTO();

                dto.Descripcion = this.Incidente.Descripcion;
                dto.Lugar = this.Incidente.Lugar;
                dto.Latitud = this.Incidente.Latitud;
                dto.Longitud = this.Incidente.Longitud;
                dto.DistanciaKM = this.Incidente.DistanciaKM;
                dto.DireccionCardinal = this.Incidente.DireccionCardinal;
                dto.TiempoEstimadoMinutos = this.Incidente.TiempoEstimadoMinutos;
                dto.HoraEstimadaLlegada = this.Incidente.HoraEstimadaLlegada;
                dto.UsuarioID = _variablesSession.Usuario.UsuarioId;
                dto.TipoAsistencia.TipoAsistenciaID = this.Incidente.TipoAsistenciaSeleccionado.TipoAsistenciaID;
                dto.CentroAtencion.CentroAtencionID = this.Incidente.CentroAtencion.CentroAtencionID;


                var rows = await this._incidenteService.GuardarIncidente(dto);

                if(rows > 0)
                {
                    MessageBox.Show("Guardado correctamente!", "Operación exitosa", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.EsIncidenteGuardado = true;

                    this.CerrarWindow(win);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        #endregion

    }
}
