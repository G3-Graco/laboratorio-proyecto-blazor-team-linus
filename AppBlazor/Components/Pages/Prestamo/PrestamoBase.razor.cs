using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using AppBlazor.Data.Models;
using AppBlazor.Data.Services;
using BlazorBootstrap;
using Core.Entidades;


namespace AppBlazor.Components
{
    public class PrestamoBase : ComponentBase
    {


        
    
        [Inject]
        public NavigationManager Navigation { get; set; }
        
        public Prestamo prestamo = new Prestamo();

        [Inject]
        PrestamoService prestamosServices { get; set; }

        public string mensaje = "";

     


        public async Task Register()
        {
            mensaje = "";
           // Response<Prestamo> respuesta = await prestamosServices.Register(prestamo);
            //if (respuesta.Ok) Navigation.NavigateTo("/", forceLoad: true);
            //else mensaje = respuesta.Message;
        }

    }
}