using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlazor.Data.Models
{
    public class Movimientos
    {
        public int IDMovimiento {get;set;}
        public  int  IDTipo {get; set;}
        public  string?  IDCuenta {get; set;}
        public  DateTime  Date {get; set;}
        public  double  Monto {get; set;}
        
    }
}