using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WebBlazor.Data.Models;
using WebBlazor.Data.Services;

namespace WebBlazor.Components
{
    public class ArchivoBase : ComponentBase
    {
        /*[Parameter]
        public EventCallback OnCuentajeCreado { get; set; }*/

        [Inject]
        public NavigationManager Navigation { get; set; }

        // [Parameter]
        public Archivo archivo = new Archivo();

        /*[Parameter]
        public EventCallback ActualizarLista { get; set; }*/

        [Inject]
        ArchivoServices archivoServices { get; set; }

        public Archivo model = new Archivo();

        protected override async Task OnInitializedAsync()
        {
            model = archivo;
        }
        public string mensaje = "";


         public async Task Actualizar()
        {
            mensaje = "";
            Response<Archivo> respuesta = await archivoServices.Update(archivo);
            if (respuesta.Ok) Navigation.NavigateTo("/", forceLoad: true);
            else mensaje = respuesta.Message;
        }

        /*public async Task Post()
        {
            var respuesta = await cuentaServices.Create(cuenta);

            if (respuesta.Ok)
            {

                await OnCuentaCreado.InvokeAsync();
                cuenta = new();

            }
        }*/
    }
}