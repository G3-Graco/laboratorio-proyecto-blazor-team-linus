using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using WebBlazor.Data.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace WebBlazor.Data.Services
{
    public class UsuarioServices
    {
        public readonly ProtectedLocalStorage _protectedLocalStorage;
        public UsuarioServices(ProtectedLocalStorage protectedLocal) {
            _protectedLocalStorage = protectedLocal;
        }

        public async Task<Response<Usuario>> Registrar(Usuario usuario) {
            Response<Usuario> respuesta = new Response<Usuario>();
            try
            {
                respuesta = await Consumer.
                    Execute<Usuario, Usuario>(
                        $"https://localhost:5096/api/Usuario", 
                        MethodHttp.POST, 
                        usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
            return respuesta;
        }

        public async Task<Response<Usuario>> Modificar(Usuario usuario) {
            Response<Usuario> respuesta = new Response<Usuario>();
            try
            {
                var jwt = await _protectedLocalStorage.GetAsync<string>("token");
			    string token = jwt.Success ? jwt.Value : "";
			    respuesta = await Consumer.
                    Execute<Usuario, Usuario>(
                        $"https://localhost:5096/api/Usuario/{usuario.Cedula}", 
                        MethodHttp.PUT, 
                        usuario, 
                        token);
            }
            catch (CryptographicException e) {
                await _protectedLocalStorage.DeleteAsync("token");
            } catch (Exception e)
            {
                throw e;
            }
            return respuesta;
        }
    }
}