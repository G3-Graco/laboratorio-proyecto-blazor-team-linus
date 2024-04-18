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
       // public  Tasas? IDTasa {get; set;}
        //public  Cuentas? IDCuenta {get; set;}
        //public virtual Cuentas? Cuenta {get; set;}

        public  DateTime  FechaDeOperacion {get; set;}
        public double Sueldo {get;set;}
        public double Monto {get;set;}
        
    }
}