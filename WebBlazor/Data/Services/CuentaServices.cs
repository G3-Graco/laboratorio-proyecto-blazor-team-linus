using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlazor.Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebBlazor.Data.Services
{
    public class CuentaServices
    {
        public async Task<Response<string>> Post(Cuentas cuenta) {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Cuentas, Cuentas>(
                        "https://localhost:7103/api/Cuentas",
                        MethodHttp.GET,
                        cuenta
                    )).Message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }

       /* public async Task<Response<List<Enemigo>>> GetAll()
        {
            Response<List<Enemigo>> response = new Response<List<Enemigo>>();
            List<Enemigo> enemigos = new List<Enemigo>();

            try
            {
                response = await Consumer
                    .Execute<List<Enemigo>, List<Enemigo>>(
                        "https://localhost:5096/api/Enemigo",
                        MethodHttp.GET,
                        enemigos
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }*/

        public async Task<Response<Cuentas>> Update(Cuentas cuenta)
        {
            Response<Cuentas> response = new Response<Cuentas>();
            try
            {
                response = await Consumer
                    .Execute<Cuentas, Cuentas>(
                        $"https://localhost:7103/api/Cuentas/{cuenta.IDCuenta}",
                        MethodHttp.PUT,
                        cuenta
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<string>> Delete(Cuentas cuenta)
        {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Cuentas, Cuentas>(
                        $"https://localhost:7103/api/Cuentas/{cuenta.IDCuenta}",
                        MethodHttp.DELETE,
                        cuenta
                    )).Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<Cuentas>> GetOne(Cuentas cuenta)
        {
            Response<Cuentas> response = new Response<Cuentas>();
            try
            {
                response = await Consumer
                    .Execute<Cuentas, Cuentas>(
                       $"https://localhost:7103/api/Cuentas/{cuenta.IDCuenta}",
                        MethodHttp.PUT,
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