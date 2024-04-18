using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WebBlazor.Data.Models;
using WebBlazor.Data.Services;

namespace WebBlazor.Components
{
    public class SesionBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public UsuarioServices usuarioService { get; set; }
        [Inject]
        public SesionServices sesionService {get; set;}

        public Usuario usuario = new();

        public string mensaje = "";
        public bool Iniciado { get; set; } = true;

        public void Cambiar() {
            Iniciado = !Iniciado;
        }
        public async Task Registrar()
        {
            mensaje = "";
            Response<Usuario> respuesta = await usuarioService.Registrar(usuario);
            if (respuesta.Ok)
            {
                Navigation.NavigateTo("/", forceLoad: true);
                Iniciado = true;
            }
            else mensaje = respuesta.Message;
        }
        public async Task Iniciar()
        {
            mensaje = "";
            var respuesta = await sesionService.IniciarSesion(usuario);
            if (respuesta.Ok) Navigation.NavigateTo("/", forceLoad: true);
            else mensaje = respuesta.Data.Token;
        }
    }
}