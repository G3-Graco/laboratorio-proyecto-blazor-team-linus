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
    public class MovimientosBase : ComponentBase
    {
       [Inject]
        public NavigationManager Navigation {get;set;}
        [Inject]
        MovimientoService movimientoservice { get; set; }
        public List<Movimientos>? lstMovimientos {get;set;} 
        public Movimientos movimientos = new();
        public Cuenta cuenta = new();
        public string mensaje = "";
    
        [Inject]
        CuentaService cuentaService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lstMovimientos = new List<Movimientos>();

            var response = await movimientoservice.GetAll();

            lstMovimientos = response.Data;
            
        }

   
        public async Task GetAll()
        {
            var response = await movimientoservice.GetAll();

            lstMovimientos = response.Data;

            //return Task.CompletedTask;
        }
    }

    
}