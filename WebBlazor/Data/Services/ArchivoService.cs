using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBlazor.Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebBlazor.Data.Services
{
    public class ArchivoServices
    {
        public async Task<Response<string>> Post(Archivo archivo) {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Archivo, Archivo>(
                        "https://localhost:7103/api/Archivos",
                        MethodHttp.GET,
                        archivo
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

        public async Task<Response<Archivo>> Update(Archivo archivo)
        {
            Response<Archivo> response = new Response<Archivo>();
            try
            {
                response = await Consumer
                    .Execute<Archivo, Archivo>(
                        $"https://localhost:7103/api/Archivos/{archivo.IDArchivo}",
                        MethodHttp.PUT,
                        archivo
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<string>> Delete(Archivo archivo)
        {
            Response<string> response = new Response<string>();
            try
            {
                response.Message = (await
                    Consumer.Execute<Archivo, Archivo(
                        $"https://localhost:7103/api/Archivos/{archivo.IDArchivo}",
                        MethodHttp.DELETE,
                        archivo
                    )).Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Response<Archivo>> GetOne(Archivo archivo)
        {
            Response<Archivo> response = new Response<Archivo>();
            try
            {
                response = await Consumer
                    .Execute<Archivo, Archivo>(
                       $"https://localhost:7103/api/Archivos/{archivo.IDArchivo}",
                        MethodHttp.PUT,
                        archivo
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