using AppBlazor.Data.Models; 
using Newtonsoft.Json;  
using System.Collections.Generic; 
using System.Text; 
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
namespace AppBlazor.Data.Services
{
    public class UsuarioService
    {
        // Método para crear un usuario
        
        public readonly ProtectedLocalStorage _protectedLocalStorage;
        public UsuarioService(ProtectedLocalStorage protectedLocal) {
            _protectedLocalStorage = protectedLocal;
        }

        public async Task<Response<Usuario>> Register(Usuario usuario) {
            Response<Usuario> respuesta = new Response<Usuario>();
            try
            {
                respuesta = await Consumer.
                    Execute<Usuario>(
                        $"https://localhost:5274/api/Usuario", 
                        methodHttp.POST, 
                        usuario,
                        ""
                        );
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
                    Execute<Usuario>(
                        $"https://localhost:5274/api/Usuario/{usuario.CI}", 
                        methodHttp.PUT, 
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

