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

        [Inject]
        public NavigationManager Navigation { get; set; }


        public Cuentas cuenta = new Cuentas();



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

    }
}