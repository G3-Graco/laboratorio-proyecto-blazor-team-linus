using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AppBlazor.Data.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace AppBlazor.Data
{
    public class Consumer
    {
        private static HttpMethod CreateHttpMethod(methodHttp method)
        {
            switch (method)
            {
                case methodHttp.GET:
                    return HttpMethod.Get; // Traer informaci�n, 
                case methodHttp.POST:
                    return HttpMethod.Post;
                case methodHttp.PUT:
                    return HttpMethod.Put;
                case methodHttp.DELETE:
                    return HttpMethod.Delete;
                default:
                    throw new NotImplementedException("Not implemented http method");
            }
        }

        public static async Task<Response<T>> Execute<T>(string url, methodHttp method, T objectRequest, string token="")
        {                                           
            Response<T> response = new Response<T>();
            try
            {

                
                using (HttpClient client = new HttpClient())
                {
                    // Agregar el token JWT al encabezado de autorización
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                  
                    var myContent = JsonConvert.SerializeObject((method != methodHttp.GET) ? method != methodHttp.DELETE ? objectRequest : "" : "");
                    var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                    bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    //Si es get o delete no le mandamos content
                    var request = new HttpRequestMessage(CreateHttpMethod(method), url)
                    {
                        Content = (method != methodHttp.GET) ? method != methodHttp.DELETE ? bytecontent : null : null
                    };

                    using (HttpResponseMessage res = await client.SendAsync(request))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                                response.Data = JsonConvert.DeserializeObject<T>(data);

                            response.StatusCode = res.StatusCode.ToString();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                response.StatusCode = "ServerError";
                var res = (HttpWebResponse)ex.Response;
                if (res != null)
                    response.StatusCode = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                response.StatusCode = "AppError";
                response.Message = ex.Message;
            }
            return response;


        }
    }
}