using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlazor.Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebBlazor.Data.Services
{
    public class PrestamosServices
    {
        public async Task<Response<string>> Post(Prestamos prestamo) {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Prestamos, Prestamos>(
                        "https://localhost:7103/api/Prestamos",
                        MethodHttp.GET,
                        prestamo
                    )).Message;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }


        public async Task<Response<Prestamos>> Update(Prestamos prestamo)
        {
            Response<Prestamos> response = new Response<Prestamos>();
            try
            {
                response = await Consumer
                    .Execute<Prestamos, Prestamos>(
                        $"https://localhost:7103/api/Prestamos/{prestamo.IDPrestamo}",
                        MethodHttp.PUT,
                        prestamo
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

/*        public async Task<Response<string>> Delete(Prestamos prestamo)
        {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Prestamos, Prestamos>(
                        $"https://localhost:7103/api/Prestamos/{prestamo.IDPrestamo}",
                        MethodHttp.DELETE,
                        prestamo
                    )).Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }*/

        public async Task<Response<Prestamos>> GetOne(Prestamos prestamo)
        {
            Response<Prestamos> response = new Response<Prestamos>();
            try
            {
                response = await Consumer
                    .Execute<Prestamos, Prestamos>(
                       $"https://localhost:7103/api/Prestamos/{prestamo.IDPrestamo}",
                        MethodHttp.PUT,
                        prestamo
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