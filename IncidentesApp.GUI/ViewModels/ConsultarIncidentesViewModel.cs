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
    internal class ConsultarIncidentesViewModel : BindableBase
    {
        private readonly IIncidenteService incidenteService;

        public ConsultarIncidentesViewModel(IIncidenteService _incidenteService)
        {
            this.incidenteService = _incidenteService;

            this.FiltrarCommand = new DelegateCommand(() => this.CargarListaIncidentes());
            this.CargarListaIncidentes();
        }

        #region Comandos
        public DelegateCommand FiltrarCommand { get; set; }
        #endregion


        #region Propiedades
        private List<IncidenciaModel> listaIncidentes;

        public List<IncidenciaModel> ListaIncidentes
        {
            get { return listaIncidentes; }
            set { SetProperty(ref listaIncidentes, value); }
        }

        private int? centroAtencionID;

        public int? CentroAtencionID
        {
            get { return centroAtencionID; }
            set { SetProperty(ref centroAtencionID, value); }
        }


        #endregion


        #region Metodos


        private async Task CargarListaIncidentes()
        {
            try
            {
                var lista = await this.incidenteService.FiltrarIncidentesPorCentroAtencionID(this.CentroAtencionID);

                var listaProcesada = lista.Select(inc => new IncidenciaModel() { 
                    IncidenteID = inc.IncidenteID,
                    Descripcion = inc.Descripcion,
                    Lugar = inc.Lugar,
                    DistanciaKM = inc.DistanciaKM,
                    TipoAsistencia = new TipoAsistenciaModel(inc.TipoAsistencia.TipoAsistenciaID, inc.TipoAsistencia.Nombre, ""),
                    CentroAtencion = new CentroAtencionModel() { Nombre = inc.CentroAtencion.Nombre, CentroAtencionID = inc.CentroAtencion.CentroAtencionID},
                    Usuario = new UsuarioModel(inc.Usuario.UsuarioId, inc.Usuario.Usuario, new PersonaModel() { Nombre = inc.Usuario.Persona.Nombre, ApellidoPaterno = inc.Usuario.Persona.ApellidoPaterno, ApellidoMaterno = inc.Usuario.Persona.ApellidoMaterno}  )
                });

                this.ListaIncidentes = listaProcesada.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

    }
}
