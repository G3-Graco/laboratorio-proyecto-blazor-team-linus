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
    public class RetirosBase : ComponentBase
    {

        [Inject]
        public NavigationManager Navigation { get; set; }

        public Movimientos movimiento = new Movimientos();

        [Inject]
        MovimientoService movimientosServices { get; set; }

        public Movimientos model = new Movimientos();

        protected override async Task OnInitializedAsync()
        {
            model = movimiento;
        }
        public string mensaje = "";


         public async Task Retirar()
        {
            mensaje = "";
            Response<Movimientos> respuesta = await movimientosServices.Register(movimiento);
            if (respuesta.Ok) Navigation.NavigateTo("/", forceLoad: true);
            else mensaje = respuesta.Message;
        }
        public async Task Register()
        {
            /*
            //if (string.IsNullOrEmpty(personaje.Message))
            //{
            //    //no enviamos la información
            //}

            var respuesta = await movimientosServices(movimiento);

            if (respuesta.Ok)
            {
                // Process the response data here
                Navigation.NavigateTo("/personajes");
                //await Re.InvokeAsync();

            }
            else
            {
                mensaje = respuesta.Message;
            }*/

        }

    }
}