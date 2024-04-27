using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Core.Entidades
{
    public class Prestamo
    {   public int IDPrestamo {get;set;}
        public int CantCuotas {get;set;}
        public  int IDTasa {get; set;} 
        public  int IDCuenta {get; set;}
        public  DateTime  FechaDeOperacion {get; set;}
        public double Monto {get;set;}
        public string Estado {get;set;}

        
    }
}