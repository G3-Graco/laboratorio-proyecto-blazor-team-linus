using AppBlazor.Data.Models; 
using Newtonsoft.Json;  
using System.Collections.Generic; 
using System.Text; 
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
namespace AppBlazor.Data.Services
{
    public class CuentaService
    {

        public class CuentaServices
        {
            public async Task<Response<string>> CreateCuenta(Cuenta cuenta) {
                Response<string> response = new Response<string>();
                try
                {
                    response.Message = (await
                        Consumer.Execute<Cuenta>(
                            "https://localhost:7103/api/Cuentas",
                            methodHttp.GET,
                            cuenta
                        )).Message;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return response;
            }
        
            public async Task<Response<Cuenta>> GetOne(Cuenta cuenta)
            {
                Response<Cuenta> response = new Response<Cuenta>();
                try
                {
                    response = await Consumer
                        .Execute<Cuenta>(
                        $"https://localhost:7103/api/Cuentas/{cuenta.IDCuenta}",
                            methodHttp.PUT,
                            cuenta
                        );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return response;
            }

            
        
        }
    }
}       

