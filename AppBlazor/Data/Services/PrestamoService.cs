using AppBlazor.Data.Models; 
using Newtonsoft.Json;  
using System.Collections.Generic; 
using System.Text; 
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Core.Entidades;
namespace AppBlazor.Data.Services
{
    public class PrestamoService
    {

        public async Task<Response<List<Prestamo>>> GetAll()
        {
            Response<List<Prestamo>> response = new Response<List<Prestamo>>();
            List<Prestamo> lstPrestamos = new List<Prestamo>();
            try
            {

                response = await Consumer
                    .Execute<List<Prestamo>>(
                        "https://localhost:5284/api/Movimiento",
                        methodHttp.GET,
                        lstPrestamos,
                        null
                    );

            }
            catch(Exception ex)
            {

            }
            return response;
        }

        public async Task<Response<Prestamo>> Register(Prestamo prestamo) {
            Response<Prestamo> respuesta = new Response<Prestamo>();
            try
            {
                respuesta = await Consumer.
                    Execute<Prestamo>(
                        $"https://localhost:5274/api/Usuario", 
                        methodHttp.POST, 
                        prestamo,
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

