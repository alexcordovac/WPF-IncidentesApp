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

            CatalogoTipoAsistencia = new ObservableCollection<TipoAsistenciaModel>();
            CatalogoTipoAsistencia.Add(new TipoAsistenciaModel(1, "Policía", "PoliceBadgeOutline"));
            CatalogoTipoAsistencia.Add(new TipoAsistenciaModel(2, "Bomberos", "FireTruck"));
            CatalogoTipoAsistencia.Add(new TipoAsistenciaModel(3, "Ambulancia", "Ambulance"));

            Incidente = new IncidenciaModel();
            this.EnviarCommand = new DelegateCommand(this.GuardarIncidente);

            //EnviarCommand
        }

        #region Comandos
        public DelegateCommand EnviarCommand { get; set; }
        #endregion

        #region Propiedades

        public ObservableCollection<TipoAsistenciaModel> CatalogoTipoAsistencia { get; set; }

        public TipoAsistenciaModel TipoAsistenciaSeleccionado { get; set; }

        public IncidenciaModel Incidente { get; set; }

        #endregion

        #region Metodos
        private void GuardarIncidente()
        {
            var rs = MessageBox.Show("¿Enviar incidencia?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (rs == MessageBoxResult.Yes)
            {
                var procesarView = this._containerProvider.Resolve<ProcesarIncidenteView>();
                procesarView.ShowDialog();
            }

        }

        #endregion


    }
}
