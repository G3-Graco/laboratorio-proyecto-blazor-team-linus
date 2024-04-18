using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlazor.Data.Models
{
    public class Sesion
    {
        public int Id {get; set;}
        public string? Token {get; set;}
        public string? Cedula_usuario {get; set;}
    }
}