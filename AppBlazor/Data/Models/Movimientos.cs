using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppBlazor.Data.Models
{
    public class Movimientos
    {
        public int IDMovimiento {get;set;}
        public  int IDTipo {get; set;}
        public  int  IDCuentaAcreditada {get; set;}
        public  int  IDCuentaDebitada {get; set;} 
        public  DateTime  Fecha {get; set;}
        public  double  Monto {get; set;} 

    }
}