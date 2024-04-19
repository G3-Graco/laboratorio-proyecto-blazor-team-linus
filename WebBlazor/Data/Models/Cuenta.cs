using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlazor.Data.Models
{
    public class Cuentas
    {
        public int IDCuenta {get;set;}
        public int CI {get;set;}

        public double Saldo {get; set;}
    }
}