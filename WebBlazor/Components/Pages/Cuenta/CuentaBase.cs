using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WebBlazor.Data.Models;
using WebBlazor.Data.Services;

namespace WebBlazor.Components
{
    public class CuentaBase : ComponentBase
    {
        /*[Parameter]
        public EventCallback OnCuentajeCreado { get; set; }*/

        [Inject]
        public NavigationManager Navigation { get; set; }

        // [Parameter]
        public Cuentas cuenta = new Cuentas();

        /*[Parameter]
        public EventCallback ActualizarLista { get; set; }*/

        [Inject]
        CuentaServices cuentaServices { get; set; }

        public Cuentas model = new Cuentas();

        protected override async Task OnInitializedAsync()
        {
            model = cuenta;
        }
        public string mensaje = "";


         public async Task Actualizar()
        {
            mensaje = "";
            Response<Cuentas> respuesta = await cuentaServices.Update(cuenta);
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