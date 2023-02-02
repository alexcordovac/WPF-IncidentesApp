using IncidentesApp.Entidades.DTO;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentesApp.GUI.Models
{
    internal class UsuarioModel : BindableBase
    {

        public UsuarioModel()
        {
            this.Persona = new PersonaModel();
        }

        public UsuarioModel(int usuarioId, string usuario, PersonaModel persona)
        {
            this.UsuarioId = usuarioId;
            this.Usuario = usuario;
            this.Persona = persona;
        }


        private int usuarioId;

        public int UsuarioId
        {
            get { return usuarioId; }
            set { SetProperty(ref usuarioId, value); }
        }


        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { SetProperty(ref usuario, value); }
        }


        private PersonaModel persona;

        public PersonaModel Persona
        {
            get { return persona; }
            set { SetProperty(ref persona, value); }
        }
    }
}
