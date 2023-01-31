using IncidentesApp.GUI.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IncidentesApp.GUI.ViewModels
{
    internal class ProcesarIncidenteViewModel
    {

        public ProcesarIncidenteViewModel()
        {
            this.CancelarCommand = new DelegateCommand<IClosable>(this.CerrarWindow);
            this.GuardarCommand = new DelegateCommand<IClosable>(this.GuardarIncidente);
        }

        #region Comandos
        public DelegateCommand<IClosable> CancelarCommand { get; set; }
        public DelegateCommand<IClosable> GuardarCommand { get; set; }
        #endregion

        #region Propiedades
        public Visibility CargandoEstacionVisibility { get; set; } = Visibility.Visible;
        public Visibility CargandoDistanciaVisibility { get; set; } = Visibility.Visible;
        public Visibility CargandoDireccionCardinalVisibility { get; set; } = Visibility.Visible;
        public Visibility CargandoTEVisibility { get; set; } = Visibility.Visible;
        public Visibility CargandoHEVisibility { get; set; } = Visibility.Visible;

        #endregion

        #region Metodos

        private void ProcesarIncidente() 
        {
            
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
