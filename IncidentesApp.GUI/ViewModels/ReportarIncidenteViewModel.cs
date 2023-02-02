using IncidentesApp.GUI.Interfaces;
using IncidentesApp.GUI.Models;
using IncidentesApp.GUI.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IncidentesApp.GUI.ViewModels
{
    internal class ReportarIncidenteViewModel : BindableBase
    {
        private readonly IContainerProvider _containerProvider;

        public ReportarIncidenteViewModel(IContainerProvider containerProvider)
        {
            this._containerProvider = containerProvider;

            //Catálogo por defecto de Tipo de Asistencia
            CatalogoTipoAsistencia = new ObservableCollection<TipoAsistenciaModel>();
            CatalogoTipoAsistencia.Add(new TipoAsistenciaModel(1, "Policía", "PoliceBadgeOutline"));
            CatalogoTipoAsistencia.Add(new TipoAsistenciaModel(2, "Bomberos", "FireTruck"));
            CatalogoTipoAsistencia.Add(new TipoAsistenciaModel(3, "Ambulancia", "Ambulance"));

            Incidente = new IncidenciaModel() { Latitud = 18.265751928562267, Longitud = -93.22412155715988 };
            this.EnviarCommand = new DelegateCommand(this.EnviarIncidente);
        }

        #region Comandos
        public DelegateCommand EnviarCommand { get; set; }
        #endregion

        #region Propiedades

        public ObservableCollection<TipoAsistenciaModel> CatalogoTipoAsistencia { get; set; }


        private IncidenciaModel incidente;

        public IncidenciaModel Incidente
        {
            get { return incidente; }
            set { SetProperty(ref incidente, value);}
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Procesa los datos de la incidencia, para calcular los datos faltantes
        /// </summary>
        private void EnviarIncidente()
        {
            

            if(this.Incidente.TipoAsistencia == null) 
            {
                MessageBox.Show("Selecciona un tipo de asistencia", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }


            if (MessageBox.Show("¿Enviar incidencia?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                //Mostrar la ventana de procesar incidente (calcular datos)
                var procesarView = this._containerProvider.Resolve<ProcesarIncidenteView>();
                var dtc = procesarView.DataContext as ProcesarIncidenteViewModel;

                dtc.Incidente = this.Incidente;
                dtc.ProcesarIncidente();

                procesarView.ShowDialog();

                if (dtc.EsIncidenteGuardado)
                {
                    this.Incidente = new IncidenciaModel();
                }
            }

        }

        #endregion


    }
}
