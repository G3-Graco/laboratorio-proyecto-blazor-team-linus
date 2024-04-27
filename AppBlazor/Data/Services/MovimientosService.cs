using AppBlazor.Data.Models; 
using Newtonsoft.Json;  
using System.Collections.Generic; 
using System.Text; 
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
namespace AppBlazor.Data.Services
{
    public class MovimientoService
    {

        public async Task<Response<List<Movimientos>>> GetAll()
        {
            Response<List<Movimientos>> response = new Response<List<Movimientos>>();
            List<Movimientos> lstPersonajes = new List<Movimientos>();
            try
            {

                response = await Consumer
                    .Execute<List<Movimientos>>(
                        "https://localhost:5284/api/Movimiento",
                        methodHttp.GET,
                        lstPersonajes,
                        null
                    );

            }
            catch(Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<Movimientos>> Register(Movimientos movimiento) {
            Response<Movimientos> respuesta = new Response<Movimientos>();
            try
            {
                respuesta = await Consumer.
                    Execute<Movimientos>(
                        $"https://localhost:5274/api/Usuario", 
                        methodHttp.POST, 
                        movimiento,
                        ""
                        );
            }
            catch (Exception e)
            {
                throw e;
            }
            return respuesta;
        }
    }
}       

