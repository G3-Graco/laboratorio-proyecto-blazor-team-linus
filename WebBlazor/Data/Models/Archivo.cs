using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlazor.Data.Models
{
    public class Archivo
    {
        public int IDArchivo {get;set;}
        public string? Documento {get;set;}
    }
}