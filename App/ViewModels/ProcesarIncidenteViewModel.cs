using IncidentesApp.GUI.Interfaces;
using IncidentesApp.GUI.Models;
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

        public ProcesarIncidenteViewModel()
        {
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

        private async void ProcesarIncidente()
        {

            await Task.Delay(2000);

            this.CargandoEstacionVisibility = Visibility.Collapsed;
            this.Incidente.CentroAtencion.Nombre = "Holaaaaaaa";
        }


        private void CerrarWindow(IClosable win)
        {
            win.Close();
        }

        private void GuardarIncidente(IClosable win)
        {

        }

        #endregion

    }
}
