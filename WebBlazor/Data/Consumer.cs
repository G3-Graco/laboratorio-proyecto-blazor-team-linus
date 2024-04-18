using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebBlazor.Data.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace WebBlazor.Data
{
    public class Consumer
    {
        private static HttpMethod CreateHttpMethod(MethodHttp method)
        {
            switch (method)
            {
                case MethodHttp.GET:
                    return HttpMethod.Get;
                case MethodHttp.POST:
                    return HttpMethod.Post;
                case MethodHttp.PUT:
                    return HttpMethod.Put;
                case MethodHttp.DELETE:
                    return HttpMethod.Delete;
                default:
                    throw new NotImplementedException("Not implemented http method");
            }
        }

        public static async Task<Response<Tout>> Execute<Tin, Tout>(string url, MethodHttp method, Tin objectRequest, string token = "")
        {
            Response<Tout> respuesta = new Response<Tout>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject((method != MethodHttp.GET) ? method != MethodHttp.DELETE ? objectRequest : "" : ""); 
                    var byteArray = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                    byteArray.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var request = new HttpRequestMessage(CreateHttpMethod(method), url)
                    {
                        Content = (method != MethodHttp.GET) ? method != MethodHttp.DELETE ? byteArray : null : null
                    };
                    if (token != "") request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    using (HttpResponseMessage res = await client.SendAsync(request))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                if (typeof(Tout) == typeof(string)) respuesta.Data = (Tout)Convert.ChangeType(data, typeof(Tout));
                                else respuesta.Data = JsonConvert.DeserializeObject<Tout>(data);
                            }
                            respuesta.StatusCode = res.StatusCode.ToString();
                            if (res.IsSuccessStatusCode) respuesta.Ok = true;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                respuesta.StatusCode = "ServerError";
                var final = (HttpWebResponse)ex.Response;
                if (final != null) respuesta.StatusCode = respuesta.StatusCode.ToString();
                respuesta.Ok = false; 
                if (!respuesta.Ok) respuesta.Message = $"No aceptable {respuesta.StatusCode}"; 
            }
            catch (JsonSerializationException) 
            {
                respuesta.StatusCode = "Token invalido";
                respuesta.Message = "vuelva a intentar";
                respuesta.Ok = false; 
            }
            catch (Exception ex)
            {
                respuesta.StatusCode = "Un Error Sucedio";
                respuesta.Message = ex.Message;
                respuesta.Ok = false;
            }
            return respuesta;
        }
    }
}