using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlazor.Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebBlazor.Data.Services
{
    public class MovimientosServices
    {
        public async Task<Response<string>> Post(Movimientos movimiento) {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Movimientos, Movimientos>(
                        "https://localhost:7103/api/Movimientos",
                        MethodHttp.GET,
                        movimiento
                    )).Message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }

        public async Task<Response<Movimientos>> Update(Movimientos movimiento)
        {
            Response<Movimientos> response = new Response<Movimientos>();
            try
            {
                response = await Consumer
                    .Execute<Movimientos, Movimientos>(
                        $"https://localhost:7103/api/Movimientos/{movimiento.IDMovimiento}",
                        MethodHttp.PUT,
                        movimiento
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<string>> Delete(Movimientos movimiento)
        {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Movimientos, Movimientos>(
                        $"https://localhost:7103/api/Movimientos/{movimiento.IDMovimiento}",
                        MethodHttp.DELETE,
                        movimiento
                    )).Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<Movimientos>> GetOne(Movimientos movimiento)
        {
            Response<Movimientos> response = new Response<Movimientos>();
            try
            {
                response = await Consumer
                    .Execute<Movimientos, Movimientos>(
                       $"https://localhost:7103/api/Movimientos/{movimiento.IDMovimiento}",
                        MethodHttp.PUT,
                        movimiento
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