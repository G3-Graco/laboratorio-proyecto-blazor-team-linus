using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WebBlazor.Data.Models;
using WebBlazor.Data.Services;

namespace WebBlazor.Components
{
    public class PrestamoBase : ComponentBase
    {


        [Inject]
        public NavigationManager Navigation { get; set; }


        public Prestamos prestamo = new Prestamos();

        [Inject]
        PrestamosServices prestamosServices { get; set; }

        public Prestamos model = new Prestamos();

        protected override async Task OnInitializedAsync()
        {
            model = prestamo;
        }
        public string mensaje = "";


         public async Task Prestamo()
        {
            mensaje = "";
            Response<Prestamos> respuesta = await prestamosServices.Update(prestamo);
            if (respuesta.Ok) Navigation.NavigateTo("/", forceLoad: true);
            else mensaje = respuesta.Message;
        }

    }
}