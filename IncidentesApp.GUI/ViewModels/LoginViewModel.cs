using IncidentesApp.Entidades.Solicitud;
using IncidentesApp.GUI.Interfaces;
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
    internal class LoginViewModel : BindableBase
    {
        private readonly IUsuarioService _loginService;

        public LoginViewModel(IUsuarioService loginService)
        {
            this.SalirCommand = new DelegateCommand<IClosable>(this.CerrarLogin);
            this.AutenticarCommand = new DelegateCommand<IClosable>(this.Autenticar);

            this._loginService = loginService;
        }

        #region Propiedades

        public UsuarioDTO UsuarioLogueado { get; set; }

        private string usuario = "admin";

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }


        private string contraseña = "admin";

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        #endregion

        #region Comandos
        public DelegateCommand<IClosable> AutenticarCommand { get; set; }
        public DelegateCommand<IClosable> SalirCommand { get; set; }
        #endregion

        #region Metodos
        private void CerrarLogin(IClosable window)
        {
            window.Close();
        }

        /// <summary>
        /// Validar credenciales del usuario, si son válidas, se cierra el login
        /// </summary>
        /// <param name="window"></param>
        private async void Autenticar(IClosable window)
        {

            var usValido = await this._loginService.Autenticar(new UsuarioDTO(this.Usuario, this.Contraseña));

            if (usValido != null)
            {
                this.UsuarioLogueado = usValido;
                this.CerrarLogin(window);
            }
            else
            {
                MessageBox.Show("Credenciales no válidas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
