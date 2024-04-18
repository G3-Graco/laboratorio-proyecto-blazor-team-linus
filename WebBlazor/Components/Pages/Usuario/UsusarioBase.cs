using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using WebBlazor.Data.Models;
using WebBlazor.Data.Services;

namespace WebBlazor.Components
{
    public class UsuarioBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        // [Inject]
        [Inject]
        public UsuarioServices usuarioservice {get; set;} 
        //public UsuarioService usuarioService = new UsuarioService(uno);
        public Usuario usuario = new();
        public string mensaje = "";
        private static readonly ProtectedLocalStorage uno;

        public async Task Modificar()
        {
            mensaje = "";
            Response<Usuario> respuesta = await usuarioservice.Modificar(usuario);
            if (respuesta.Ok) Navigation.NavigateTo("/", forceLoad: true);
            else mensaje = respuesta.Message;
        }
    }
}