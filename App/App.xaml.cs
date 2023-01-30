using IncidentesApp.GUI.ViewModels;
using IncidentesApp.GUI.Views;
using IncidentesApp.Repositorios.Interfaces;
using IncidentesApp.Repositorios.Repositorios;
using IncidentesApp.Servicios.Interfaces;
using IncidentesApp.Servicios.Servicios;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace IncidentesApp.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // register other needed services herecontainerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ConsultarIncidentesView>();
            containerRegistry.RegisterForNavigation<ReportarIncidenteView>();

            var cnn = ConfigurationManager.ConnectionStrings["SQLServerConn"].ConnectionString;

            containerRegistry.Register<IDbConnection>((r) => new SqlConnection(cnn));

            containerRegistry.Register<IUsuarioService, UsuarioService>();
            containerRegistry.Register<IUsuarioRepository, UsuarioRepository>();
        }

        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            
            return w;
        }

        protected override void OnInitialized()
        {
            //Hacer login antes de mostrar la ventana inicial
            var login = Container.Resolve<LoginView>();

            login.ShowDialog();

            if (login.DataContext is LoginViewModel logindtc && !logindtc.Autenticado)
                System.Windows.Application.Current.Shutdown();



            base.OnInitialized();
        }
    }
}
