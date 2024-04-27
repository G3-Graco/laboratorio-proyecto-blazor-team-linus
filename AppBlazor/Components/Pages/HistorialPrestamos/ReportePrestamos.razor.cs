using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using AppBlazor.Data.Models;
using AppBlazor.Data.Services;
using BlazorBootstrap;
using AppBlazor.Components.Pages.Prestamo;


namespace AppBlazor.Components
{
    public class ReportePrestamosBase : ComponentBase
    {
       [Inject]
        public NavigationManager Navigation {get;set;}
        [Inject]
        PrestamoService prestamoService { get; set; }
        public List<Prestamo>? lstPrestamo {get;set;} 
        public Prestamo prestamo = new();
        public string mensaje = "";
    
        [Inject]
        CuentaService cuentaService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lstPrestamo = new List<Prestamo>();

            var response = await prestamoService.GetAll();

            //lstPrestamo = response.Data;
            
        }

   
        public async Task GetAll()
        {
            var response = await prestamoService.GetAll();

            //lstPrestamo = response.Data;

            //return Task.CompletedTask;
        }
    }

    
}