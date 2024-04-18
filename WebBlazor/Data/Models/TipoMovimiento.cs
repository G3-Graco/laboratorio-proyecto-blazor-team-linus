using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlazor.Data.Models
{
    public class TipoMovimiento
    {        
        public int IDTipo {get;set;}
        public  string? Nombre {get; set;}
        
    }
}