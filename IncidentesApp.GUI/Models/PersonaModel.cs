using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.GUI.Models
{
    internal class PersonaModel : BindableBase
    {


        private int personaID;

        public int PersonaID
        {
            get { return personaID; }
            set { SetProperty(ref personaID, value); }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }


        private string apellidoPaterno;

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { SetProperty(ref apellidoPaterno, value); }
        }


        private string apellidoMaterno;

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { SetProperty(ref apellidoMaterno, value); }
        }


        private byte? edad;

        public byte? Edad
        {
            get { return edad; }
            set { SetProperty(ref edad, value); }
        }

    }
}
