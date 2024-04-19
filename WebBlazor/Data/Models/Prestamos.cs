using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlazor.Data.Models
{
    public class Prestamos
    {
        public int IDPrestamo {get;set;}
        public int CantCuotas {get;set;}
        public  int IDTasa {get; set;} //FK
        public  int IDCuenta {get; set;}
        public double Sueldo {get;set;}
        public double Monto {get;set;}
        
        public string Estado {get;set;}

    }
}