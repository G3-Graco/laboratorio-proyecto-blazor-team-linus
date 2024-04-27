using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using AppBlazor.Data.Models;
using AppBlazor.Data.Services;
using BlazorBootstrap;


namespace AppBlazor.Components
{
    public class UsuarioBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        // [Inject]
        [Inject]
        public UsuarioService usuarioservice {get; set;} 
        //public UsuarioService usuarioService = new UsuarioService(uno);
        public Usuario usuario = new();
        public string mensaje = "";
        private Modal modal;

        private void OnModalInitialized(Modal modal)
        {
            this.modal = modal;
        }


        public async Task Register()
        {
            mensaje = "";
            Response<Usuario> respuesta = await usuarioservice.Register(usuario);
            if (respuesta.Ok) Navigation.NavigateTo("/", forceLoad: true);
            else mensaje = respuesta.Message;
        }

        public async Task CloseModal()
		{
			await modal.HideAsync();
		}


    }

    
}